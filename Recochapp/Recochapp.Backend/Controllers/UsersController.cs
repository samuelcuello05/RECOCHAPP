using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Recochapp.Backend.Data;
using Recochapp.Shared.Entities;
using System.Runtime.CompilerServices;

namespace Recochapp.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly DataContext _dbcontext;
        public UsersController(DataContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            try
            {
                return Ok(await _dbcontext.Users.ToListAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            try
            {
                var user = await _dbcontext.Users.FindAsync(id);
                if (user == null)
                {
                    return NotFound();
                }
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(User user)
        {
            try
            {
                var existingUser = _dbcontext.Users.FirstOrDefault(u => u.Email.ToLower() == user.Email);
                if(existingUser!=null)
                {
                    return BadRequest("Ya te encuentras registrado en nuestra aplicación.");
                }
                _dbcontext.Add(user);
                await _dbcontext.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync(User user)
        {
            try
            {
                var currentUser = await _dbcontext.Users.FindAsync(user.Id);
                if (currentUser == null)
                {
                    return NotFound();
                }
                
                currentUser.Name = user.Name;
                currentUser.Surname = user.Surname;
                currentUser.Email = user.Email;
                currentUser.PhoneNumber = user.PhoneNumber;
                currentUser.DateOfBirth = user.DateOfBirth;
                currentUser.ImageUrl = user.ImageUrl;
                _dbcontext.Update(currentUser);
                await _dbcontext.SaveChangesAsync();
                return Ok(currentUser);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                var user = await _dbcontext.Users.FindAsync(id);
                if (user == null)
                {
                    return NotFound();
                }
                _dbcontext.Remove(user);
                await _dbcontext.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
