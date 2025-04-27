using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Recochapp.Backend.Data;
using Recochapp.Shared.Entities;

namespace Recochapp.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstablishmentsController : ControllerBase
    {
        private readonly DataContext _dbcontext;
        public EstablishmentsController(DataContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            try
            {
                return Ok(await _dbcontext.Establishments.ToListAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(Establishment establishment)
        {
            try
            {
                _dbcontext.Add(establishment);
                await _dbcontext.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
