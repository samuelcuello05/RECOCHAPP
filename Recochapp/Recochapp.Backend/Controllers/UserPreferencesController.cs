using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Recochapp.Backend.Data;
using Recochapp.Shared.Entities;

namespace Recochapp.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserPreferencesController : ControllerBase
    {
        private readonly DataContext _dbcontext;
        public UserPreferencesController(DataContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            try
            {
                return Ok(await _dbcontext.UserPreferences.ToListAsync());
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
                var UserPreference = await _dbcontext.UserPreferences.FindAsync(id);
                if (UserPreference == null)
                {
                    return NotFound();
                }
                return Ok(UserPreference);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(UserPreference UserPreference)
        {
            try
            {
                _dbcontext.Add(UserPreference);
                await _dbcontext.SaveChangesAsync();
                return Ok(UserPreference);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
