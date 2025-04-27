using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Recochapp.Backend.Data;
using Recochapp.Shared.Entities;

namespace Recochapp.Backend.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class PreferencesController : ControllerBase
    {
        private readonly DataContext _dbcontext;
        public PreferencesController(DataContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            try
            {
                return Ok(await _dbcontext.Preferences.ToListAsync());
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
                var Preference = await _dbcontext.Preferences.FindAsync(id);
                if (Preference == null)
                {
                    return NotFound();
                }
                return Ok(Preference);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(Preference preference)
        {
            try
            {
                var establishment = await _dbcontext.Establishments.FirstOrDefaultAsync(e => e.Id == preference.EstablishmentId);
                if (establishment == null)
                {
                    return BadRequest("El establecimiento no existe.");
                }

                preference.EstablishmentName = establishment.Name;

                _dbcontext.Add(preference);
                await _dbcontext.SaveChangesAsync();
                return Ok(preference);
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
                var preference = await _dbcontext.Preferences.FindAsync(id);
                if (preference == null)
                {
                    return NotFound();
                }
                _dbcontext.Remove(preference);
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
