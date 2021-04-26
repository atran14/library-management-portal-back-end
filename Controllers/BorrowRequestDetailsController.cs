using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using back_end.DatabaseContexts;
using back_end.Models;
using System.Data;
using back_end.Services.DALs;
using Microsoft.AspNetCore.Authorization;

namespace back_end.Controllers
{
    // [Authorize(Roles = "PowerUser, NormalUser")]
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class BorrowRequestDetailsController : ControllerBase
    {

        private IAsyncBorrowRequestDetailsRepository _repository;

        public BorrowRequestDetailsController(LibraryContext context)
        {
            _repository = new AsyncBorrowRequestDetailsRepository(context);
        }

        // GET: api/BorrowRequestDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BorrowRequestDetailsResponse>>> GetBorrowRequestDetails()
        {
            return await _repository.GetAll()
            .Select(brd => new BorrowRequestDetailsResponse
            {
                Id = brd.Id,
                BorrowRequestId = brd.BorrowRequestId,
                RequestedBookId = brd.RequestedBookId,
                RequestedBook = brd.RequestedBook.Name
            })
            .ToListAsync();
        }

        // GET: api/BorrowRequestDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BorrowRequestDetailsResponse>> GetBorrowRequestDetails(int id)
        {
            var borrowRequestDetails = await _repository.GetById(id);

            if (borrowRequestDetails == null)
            {
                return NotFound();
            }

            var borrowRequestDetailsResponse = new BorrowRequestDetailsResponse
            {
                Id = borrowRequestDetails.Id,
                BorrowRequestId = borrowRequestDetails.BorrowRequestId,
                RequestedBookId = borrowRequestDetails.RequestedBookId,
                RequestedBook = borrowRequestDetails.RequestedBook.Name
            };
            return Ok(borrowRequestDetailsResponse);
        }

        // PUT: api/BorrowRequestDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Roles = "PowerUser")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBorrowRequestDetails(int id, BorrowRequestDetails borrowRequestDetails)
        {
            try
            {
                await _repository.Update(id, borrowRequestDetails);
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

        // POST: api/BorrowRequestDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BorrowRequestDetailsResponse>> PostBorrowRequestDetails(BorrowRequestDetails borrowRequestDetails)
        {
            try
            {
                await _repository.Create(borrowRequestDetails);
            }
            catch (ArgumentException e)
            {
                return BadRequest(e.Message);
            }

            return CreatedAtAction("GetBorrowRequestDetails", new { id = borrowRequestDetails.Id }, borrowRequestDetails);
        }

        // DELETE: api/BorrowRequestDetails/5
        [Authorize(Roles = "PowerUser")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBorrowRequestDetails(int id)
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
