using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SkyForecastAPI.Models;

namespace SkyForecastAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClimasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ClimasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Climas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Clima>>> GetClima()
        {
            return await _context.Clima.ToListAsync();
        }

        // GET: api/Climas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Clima>> GetClima(int id)
        {
            var clima = await _context.Clima.FindAsync(id);

            if (clima == null)
            {
                return NotFound();
            }

            return clima;
        }

        // PUT: api/Climas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClima(int id, Clima clima)
        {
            if (id != clima.Id)
            {
                return BadRequest();
            }

            _context.Entry(clima).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClimaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Climas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Clima>> PostClima(Clima clima)
        {
            _context.Clima.Add(clima);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClima", new { id = clima.Id }, clima);
        }

        // DELETE: api/Climas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClima(int id)
        {
            var clima = await _context.Clima.FindAsync(id);
            if (clima == null)
            {
                return NotFound();
            }

            _context.Clima.Remove(clima);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClimaExists(int id)
        {
            return _context.Clima.Any(e => e.Id == id);
        }
    }
}
