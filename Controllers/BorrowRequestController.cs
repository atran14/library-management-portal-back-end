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

namespace back_end.Controllers
{
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
        public async Task<ActionResult<IEnumerable<BorrowRequest>>> GetBorrowRequest()
        {
            return await _repository.GetAll().ToListAsync();
        }

        // GET: api/BorrowRequest/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BorrowRequest>> GetBorrowRequest(int id)
        {
            var borrowRequest = await _repository.GetById(id);

            if (borrowRequest == null)
            {
                return NotFound(id);
            }

            return borrowRequest;
        }

        // PUT: api/BorrowRequest/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
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
        public async Task<ActionResult<BorrowRequest>> PostBorrowRequest(BorrowRequest borrowRequest)
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
