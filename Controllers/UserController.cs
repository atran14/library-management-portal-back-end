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
    // [Authorize(Roles = "PowerUser")]
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IAsyncUserRepository _repository;

        public UserController(LibraryContext context)
        {
            _repository = new AsyncUserRepository(context);
        }

        // GET: api/User
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserResponse>>> GetUser()
        {
            return await _repository.GetAll()
                .Select(u => new UserResponse
                {
                    Id = u.Id,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    DOB = u.DOB
                })
                .ToListAsync();
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserResponse>> GetUser(int id)
        {
            var user = await _repository.GetById(id);

            if (user == null)
            {
                return NotFound();
            }

            var userResponse = new UserResponse
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                DOB = user.DOB
            };
            return userResponse;
        }

        // PUT: api/User/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            try
            {
                await _repository.Update(id, user);
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

        // POST: api/User
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserResponse>> PostUser(User user)
        {
            await _repository.Create(user);

            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
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
