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
    public class CalendarDaysController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CalendarDaysController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/CalendarDays
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CalendarDay>>> GetCalendarDays()
        {
            return await _context.CalendarDays.ToListAsync();
        }

        // GET: api/CalendarDays/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CalendarDay>> GetCalendarDay(int id)
        {
            var calendarDay = await _context.CalendarDays.FindAsync(id);

            if (calendarDay == null)
            {
                return NotFound();
            }

            return calendarDay;
        }

        // PUT: api/CalendarDays/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCalendarDay(int id, CalendarDay calendarDay)
        {
            if (id != calendarDay.UniqueNumber)
            {
                return BadRequest();
            }

            _context.Entry(calendarDay).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CalendarDayExists(id))
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

        // POST: api/CalendarDays
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CalendarDay>> PostCalendarDay(CalendarDay calendarDay)
        {
            _context.CalendarDays.Add(calendarDay);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCalendarDay", new { id = calendarDay.UniqueNumber }, calendarDay);
        }

        // DELETE: api/CalendarDays/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCalendarDay(int id)
        {
            var calendarDay = await _context.CalendarDays.FindAsync(id);
            if (calendarDay == null)
            {
                return NotFound();
            }

            _context.CalendarDays.Remove(calendarDay);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CalendarDayExists(int id)
        {
            return _context.CalendarDays.Any(e => e.UniqueNumber == id);
        }
    }
}
