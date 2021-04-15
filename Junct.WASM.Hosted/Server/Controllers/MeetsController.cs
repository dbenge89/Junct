using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Junct.WASM.Hosted.Server.Data;
using Junct.WASM.Hosted.Shared.Models;

namespace Junct.WASM.Hosted.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeetsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MeetsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Meets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Meet>>> GetMeets()
        {
            return await _context.Meets.ToListAsync();
        }

        // GET: api/Meets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Meet>> GetMeet(int id)
        {
            var meet = await _context.Meets.FindAsync(id);

            if (meet == null)
            {
                return NotFound();
            }

            return meet;
        }

        // PUT: api/Meets/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMeet(int id, Meet meet)
        {
            if (id != meet.Id)
            {
                return BadRequest();
            }

            _context.Entry(meet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MeetExists(id))
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

        // POST: api/Meets
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Meet>> PostMeet(Meet meet)
        {
            _context.Meets.Add(meet);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMeet", new { id = meet.Id }, meet);
        }

        // DELETE: api/Meets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMeet(int id)
        {
            var meet = await _context.Meets.FindAsync(id);
            if (meet == null)
            {
                return NotFound();
            }

            _context.Meets.Remove(meet);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MeetExists(int id)
        {
            return _context.Meets.Any(e => e.Id == id);
        }
    }
}
