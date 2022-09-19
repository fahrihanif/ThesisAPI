using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using REST.Context;
using REST.Models;

namespace REST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterviewsController : ControllerBase
    {
        private readonly MyContext _context;

        public InterviewsController(MyContext context) => _context = context;

        [HttpGet]
        public async Task<ActionResult<Interview>> Get()
        {
            return Ok(await _context.Interviews.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<Interview>> Post(Interview interview)
        {
            await _context.Interviews.AddAsync(interview);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new {id = interview.Id}, interview);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Interview interview)
        {
            if (id != interview.Id)
            {
                return BadRequest();
            }

            _context.Entry(interview).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InterviewExist(id))
                {
                    return NotFound();
                } else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            if (_context.Interviews == null)
            {
                return NotFound();
            }

            var interview = await _context.Interviews.FindAsync(id);
            if (interview == null)
            {
                return NotFound();
            }

            _context.Interviews.Remove(interview);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InterviewExist(int id)
        {
            return (_context.Interviews?.Any(i => i.Id == id)).GetValueOrDefault();
        }
    }
}
