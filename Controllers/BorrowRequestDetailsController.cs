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

namespace back_end.Controllers
{
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
        public async Task<ActionResult<IEnumerable<BorrowRequestDetails>>> GetBorrowRequestDetails()
        {
            return await _repository.GetAll().ToListAsync();
        }

        // GET: api/BorrowRequestDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BorrowRequestDetails>> GetBorrowRequestDetails(int id)
        {
            var borrowRequestDetails = await _repository.GetById(id);

            if (borrowRequestDetails == null)
            {
                return NotFound();
            }

            return Ok(borrowRequestDetails);
        }

        // PUT: api/BorrowRequestDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
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
                    return BadRequest();
                }
                else
                {
                    return NotFound();
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
        public async Task<ActionResult<BorrowRequestDetails>> PostBorrowRequestDetails(BorrowRequestDetails borrowRequestDetails)
        {
            await _repository.Create(borrowRequestDetails);

            return CreatedAtAction("GetBorrowRequestDetails", new { id = borrowRequestDetails.Id }, borrowRequestDetails);
        }

        // DELETE: api/BorrowRequestDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBorrowRequestDetails(int id)
        {
            try
            {
                await _repository.Delete(id);
            }
            catch (ArgumentException)
            {
                return NotFound();
            }
            return NoContent();
        }

    }
}
