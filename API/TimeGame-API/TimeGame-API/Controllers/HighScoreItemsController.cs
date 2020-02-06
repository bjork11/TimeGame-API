using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimeGame_API.Models;

namespace TimeGame_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HighScoreItemsController : ControllerBase
    {
        private readonly HighScoreContext _context;

        public HighScoreItemsController(HighScoreContext context)
        {
            _context = context;
        }

        // GET: api/HighScoreItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HighScoreItem>>> GetHighScoreItems()
        {
            return await _context.HighScoreItems.ToListAsync();
        }

        // GET: api/HighScoreItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HighScoreItem>> GetHighScoreItem(int id)
        {
            var highScoreItem = await _context.HighScoreItems.FindAsync(id);

            if (highScoreItem == null)
            {
                return NotFound();
            }

            return highScoreItem;
        }

        // PUT: api/HighScoreItems/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHighScoreItem(int id, HighScoreItem highScoreItem)
        {
            if (id != highScoreItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(highScoreItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HighScoreItemExists(id))
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

        // POST: api/HighScoreItems
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<HighScoreItem>> PostHighScoreItem(HighScoreItem highScoreItem)
        {
            _context.HighScoreItems.Add(highScoreItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetHighScoreItem), new { id = highScoreItem.Id }, highScoreItem);
        }

        // DELETE: api/HighScoreItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HighScoreItem>> DeleteHighScoreItem(int id)
        {
            var highScoreItem = await _context.HighScoreItems.FindAsync(id);
            if (highScoreItem == null)
            {
                return NotFound();
            }

            _context.HighScoreItems.Remove(highScoreItem);
            await _context.SaveChangesAsync();

            return highScoreItem;
        }

        private bool HighScoreItemExists(int id)
        {
            return _context.HighScoreItems.Any(e => e.Id == id);
        }
    }
}
