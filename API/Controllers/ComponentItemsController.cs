using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComponentItemsController : ControllerBase
    {
        private readonly ComponentContext _context;

        public ComponentItemsController(ComponentContext context)
        {
            _context = context;
        }

        // GET: api/ComponentItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ComponentItem>>> GetComponentItems()
        {
            return await _context.ComponentItems.ToListAsync();
        }

        // GET: api/ComponentItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ComponentItem>> GetComponentItem(long id)
        {
            var componentItem = await _context.ComponentItems.FindAsync(id);

            if (componentItem == null)
            {
                return NotFound();
            }

            return componentItem;
        }

        // PUT: api/ComponentItems/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComponentItem(long id, ComponentItem componentItem)
        {
            if (id != componentItem.comp_id)
            {
                return BadRequest();
            }

            _context.Entry(componentItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComponentItemExists(id))
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

        // POST: api/ComponentItems
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<ComponentItem>> PostComponentItem(ComponentItem componentItem)
        {
            _context.ComponentItems.Add(componentItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetComponentItem", new { id = componentItem.comp_id }, componentItem);
        }

        // DELETE: api/ComponentItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ComponentItem>> DeleteComponentItem(long id)
        {
            var componentItem = await _context.ComponentItems.FindAsync(id);
            if (componentItem == null)
            {
                return NotFound();
            }

            _context.ComponentItems.Remove(componentItem);
            await _context.SaveChangesAsync();

            return componentItem;
        }

        private bool ComponentItemExists(long id)
        {
            return _context.ComponentItems.Any(e => e.comp_id == id);
        }
    }
}
