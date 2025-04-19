using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Recochapp.Backend.Data;
using Recochapp.Shared.Entities;

namespace Recochapp.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GroupsController : ControllerBase
    {
        private readonly DataContext _dbcontext;
        public GroupsController(DataContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            try
            {
                return Ok(await _dbcontext.Groups.ToListAsync());
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
                var Group = await _dbcontext.Groups.FindAsync(id);
                if (Group == null)
                {
                    return NotFound();
                }
                return Ok(Group);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(Group Group)
        {
            try
            {
                Group.AccessCode = await GenerateUniqueAccessCodeAsync();
                _dbcontext.Add(Group);
                await _dbcontext.SaveChangesAsync();
                return Ok(Group);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync(Group Group)
        {
            try
            {
                var currentGroup = await _dbcontext.Groups.FindAsync(Group.Id);
                if (currentGroup == null)
                {
                    return NotFound();
                }

                currentGroup.Name = Group.Name;
                currentGroup.ImageUrl = Group.ImageUrl;
                _dbcontext.Update(currentGroup);
                await _dbcontext.SaveChangesAsync();
                return Ok(currentGroup);
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
                var Group = await _dbcontext.Groups.FindAsync(id);
                if (Group == null)
                {
                    return NotFound();
                }
                _dbcontext.Remove(Group);
                await _dbcontext.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private async Task<string> GenerateUniqueAccessCodeAsync()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();

            string code;
            do
            {
                code = new string(Enumerable.Repeat(chars, 8)
                    .Select(s => s[random.Next(s.Length)]).ToArray());
            } while (await _dbcontext.Groups.AnyAsync(g => g.AccessCode == code));

            return code;
        }

    }
}
