using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using back_end.DatabaseContexts;
using back_end.Models;
using back_end.Services.DALs;
using Microsoft.AspNetCore.Authorization;

namespace back_end.Controllers
{
    // [Authorize(Roles = "PowerUser, NormalUser")]
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class BorrowRequestController : ControllerBase
    {
        private IAsyncBorrowRequestRepository _repository;
        // private readonly LibraryContext _context;

        public BorrowRequestController(LibraryContext context)
        {
            _repository = new AsyncBorrowRequestRepository(context);
        }

        // GET: api/BorrowRequest
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BorrowRequestResponse>>> GetBorrowRequest()
        {
            return await _repository.GetAll()
                .Select(br => new BorrowRequestResponse
                {
                    Id = br.Id,
                    RequestUserId = br.RequestUserId,
                    RequestUser = $"{br.RequestUser.FirstName} {br.RequestUser.LastName}",
                    BorrowRequestDate = br.BorrowRequestDate,
                    BorrowUntilDate = br.BorrowUntilDate,
                    ActionTime = br.ActionTime ?? default(DateTime),
                    ActionByUserId = br.ActionByUserId ?? 0,
                    ActionByUser = br.ActionByUser != null
                                    ? $"{br.ActionByUser.FirstName} {br.ActionByUser.LastName} (super user)"
                                    : "(waiting)",
                    BorrowRequestDetailsIds = br.BorrowRequestDetails.Select(brd => brd.Id).ToList()
                })
                .ToListAsync();
        }

        // GET: api/BorrowRequest/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BorrowRequestResponse>> GetBorrowRequest(int id)
        {
            var borrowRequest = await _repository.GetById(id);

            if (borrowRequest == null)
            {
                return NotFound(id);
            }

            var borrowRequestResponse = new BorrowRequestResponse
            {
                Id = borrowRequest.Id,
                RequestUserId = borrowRequest.RequestUserId,
                RequestUser = $"{borrowRequest.RequestUser.FirstName} {borrowRequest.RequestUser.LastName}",
                BorrowRequestDate = borrowRequest.BorrowRequestDate,
                BorrowUntilDate = borrowRequest.BorrowUntilDate,
                ActionTime = borrowRequest.ActionTime ?? default(DateTime),
                ActionByUserId = borrowRequest.ActionByUserId ?? 0,
                ActionByUser = borrowRequest.ActionByUser != null
                                ? $"{borrowRequest.ActionByUser.FirstName} {borrowRequest.ActionByUser.LastName} (super user)"
                                : "(waiting)",
                BorrowRequestDetailsIds = borrowRequest.BorrowRequestDetails.Select(brd => brd.Id).ToList()
            };
            return borrowRequestResponse;
        }

        // PUT: api/BorrowRequest/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Roles = "PowerUser")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBorrowRequest(int id, BorrowRequest borrowRequest)
        {
            try
            {
                await _repository.Update(id, borrowRequest);
            }
            catch (ArgumentException e)
            {
                if (e.InnerException == null)
                {
                    return BadRequest(e.Message);
                }
                else
                {
                    return NotFound(e.Message);
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return NoContent();
        }

        // POST: api/BorrowRequest
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BorrowRequestResponse>> PostBorrowRequest(BorrowRequest borrowRequest)
        {
            try
            {
                await _repository.Create(borrowRequest);
            }
            catch (ArgumentException e)
            {
                return BadRequest(e.Message);
            }

            return CreatedAtAction("GetBorrowRequest", new { id = borrowRequest.Id }, borrowRequest);
        }

        // DELETE: api/BorrowRequest/5
        [Authorize(Roles = "PowerUser")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBorrowRequest(int id)
        {
            try
            {
                await _repository.Delete(id);
            }
            catch (ArgumentException e)
            {
                return NotFound(e.Message);
            }
            return NoContent();
        }
    }
}
