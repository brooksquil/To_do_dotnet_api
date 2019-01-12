using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using first_dotnet_web_api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace first_dotnet_web_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private readonly ToDoContext _context;

        public ToDoController(ToDoContext context)
        {
            _context = context;

            if (_context.ToDoItems.Count() == 0)
            {
                _context.ToDoItems.Add(new ToDoItem { Name = "Item 1" });
                _context.SaveChanges();
            }
        }

        // GET: api/Todo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ToDoItem>>> GetToDoItems()
        {
            return await _context.ToDoItems.ToListAsync();
        }

        // GET: api/Todo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ToDoItem>> GetToDoItem(long id)
        {
            var ToDoItem = await _context.ToDoItems.FindAsync(id);

            if (ToDoItem == null)
            {
                return NotFound();
            }

            return ToDoItem;
        }

        // POST: api/Todo
        [HttpPost]
        public async Task<ActionResult<ToDoItem>> PostToDoItem(ToDoItem ToDoItem)
        {
            _context.ToDoItems.Add(ToDoItem);
            await _context.SaveChangesAsync();

        return CreatedAtAction("GetToDoItem", new { id = ToDoItem.Id }, ToDoItem);
        }

        // PUT: api/Todo/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutToDoItem(long id, ToDoItem ToDoItem)
        {
            if (id != ToDoItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(ToDoItem).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Todo/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ToDoItem>> DeleteToDoItem(long id)
        {
            var ToDoItem = await _context.ToDoItems.FindAsync(id);
            if (ToDoItem == null)
            {
                return NotFound();
            }

            _context.ToDoItems.Remove(ToDoItem);
            await _context.SaveChangesAsync();

            return ToDoItem;
        }

    }
}
