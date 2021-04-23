using System.Data;
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
    [Authorize(Roles = "PowerUser, NormalUser")]
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IAsyncBookRepository _repository;

        public BookController(LibraryContext context)
        {
            _repository = new AsyncBookRepository(context);
        }

        // GET: api/Book
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookResponse>>> GetBooks()
        {
            return await _repository.GetAll()
                .Include(b => b.Category)
                .Select(b => new BookResponse
                {
                    Id = b.Id,
                    CategoryId = b.CategoryId,
                    Name = b.Name,
                    Authors = b.Authors,
                    Category = b.Category.Name,
                    Description = b.Description
                })
                .ToListAsync();
        }

        // GET: api/Book/5
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<ActionResult<BookResponse>> GetBook(int id)
        {
            var book = await _repository.GetById(id);
            if (book == null)
            {
                return NotFound();
            }

            var bookResponse = new BookResponse
            {
                Id = book.Id,
                CategoryId = book.CategoryId,
                Name = book.Name,
                Authors = book.Authors,
                Category = book.Category.Name,
                Description = book.Description
            };
            return Ok(bookResponse);
        }

        // PUT: api/Book/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Roles = "PowerUser")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook(int id, Book book)
        {
            try
            {
                await _repository.Update(id, book);
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
            catch (DBConcurrencyException)
            {
                throw;
            }

            return NoContent();
        }

        // POST: api/Book
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Roles = "PowerUser")]
        [HttpPost]
        public async Task<ActionResult<BookResponse>> PostBook(Book book)
        {
            await _repository.Create(book);

            return CreatedAtAction("GetBook", new { id = book.Id }, book);
        }

        // DELETE: api/Book/5
        [Authorize(Roles = "PowerUser")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
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
