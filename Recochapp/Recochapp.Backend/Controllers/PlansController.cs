using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Recochapp.Backend.Data;
using Recochapp.Shared.Entities;

namespace Recochapp.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlansController : ControllerBase
    {
        private readonly DataContext _dbcontext;
        public PlansController(DataContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            try
            {
                return Ok(await _dbcontext.Plans.ToListAsync());
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
                var Plan = await _dbcontext.Plans.FindAsync(id);
                if (Plan == null)
                {
                    return NotFound();
                }
                return Ok(Plan);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(Plan Plan)
        {
            try
            {
                if (Plan.GroupId == 0)
                {
                    return BadRequest("Debes seleccionar un grupo para crear el plan.");
                }
                if (Plan.EstablishmentId == 0)
                {
                    return BadRequest("Debes seleccionar un establecimiento para crear el plan.");
                }

                var currentDate = DateTime.Now;
                if (Plan.Date < currentDate.AddDays(-1))
                {
                    return BadRequest("La fecha para realizar el plan debe ser una fecha futura.");
                }

                _dbcontext.Add(Plan);
                await _dbcontext.SaveChangesAsync();
                return Ok();
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
                var Plan = await _dbcontext.Plans.FindAsync(id);
                if (Plan == null)
                {
                    return NotFound();
                }
                _dbcontext.Remove(Plan);
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
