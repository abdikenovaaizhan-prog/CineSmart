using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CineSmart.API;

namespace CineSmart.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComboItemsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ComboItemsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ComboItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ComboItem>>> GetComboItems()
        {
            return await _context.ComboItems.ToListAsync();
        }

        // GET: api/ComboItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ComboItem>> GetComboItem(int id)
        {
            var comboItem = await _context.ComboItems.FindAsync(id);

            if (comboItem == null)
            {
                return NotFound();
            }

            return comboItem;
        }

        // POST: api/ComboItems
        [HttpPost]
        public async Task<ActionResult<ComboItem>> PostComboItem(ComboItem comboItem)
        {
            _context.ComboItems.Add(comboItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetComboItem), new { id = comboItem.Id }, comboItem);
        }
    }
}