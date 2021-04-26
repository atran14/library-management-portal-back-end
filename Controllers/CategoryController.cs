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
    public class CategoryController : ControllerBase
    {

        private IAsyncCategoryRepository _repository;

        public CategoryController(LibraryContext context)
        {
            _repository = new AsyncCategoryRepository(context);
        }

        // GET: api/Category
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryResponse>>> GetCategory()
        {
            return await _repository.GetAll()
                .Select(c => new CategoryResponse
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToListAsync();
        }

        // GET: api/Category/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategory(int id)
        {
            var category = await _repository.GetById(id);

            if (category == null)
            {
                return NotFound();
            }

            var categoryResponse = new CategoryResponse
            {
                Id = category.Id,
                Name = category.Name,
            };
            return Ok(categoryResponse);
        }

        // PUT: api/Category/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(int id, Category category)
        {
            try
            {
                await _repository.Update(id, category);
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

        // POST: api/Category
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CategoryResponse>> PostCategory(Category category)
        {
            await _repository.Create(category);

            return CreatedAtAction("GetCategory", new { id = category.Id }, category);
        }

        // DELETE: api/Category/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
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
