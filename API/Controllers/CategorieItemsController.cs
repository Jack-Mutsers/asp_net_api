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
    public class CategorieItemsController : ControllerBase
    {
        private readonly CategorieContext _context;

        public CategorieItemsController(CategorieContext context)
        {
            _context = context;
        }

        // GET: api/CategorieItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategorieItem>>> GetCategorieItems()
        {
            return await _context.CategorieItems.ToListAsync();
        }

        // GET: api/CategorieItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CategorieItem>> GetCategorieItem(long id)
        {
            var categorieItem = await _context.CategorieItems.FindAsync(id);

            if (categorieItem == null)
            {
                return NotFound();
            }

            return categorieItem;
        }

        // PUT: api/CategorieItems/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategorieItem(long id, CategorieItem categorieItem)
        {
            if (id != categorieItem.cat_id)
            {
                return BadRequest();
            }

            _context.Entry(categorieItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategorieItemExists(id))
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

        // POST: api/CategorieItems
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<CategorieItem>> PostCategorieItem(CategorieItem categorieItem)
        {
            _context.CategorieItems.Add(categorieItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCategorieItem", new { id = categorieItem.cat_id }, categorieItem);
        }

        // DELETE: api/CategorieItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CategorieItem>> DeleteCategorieItem(long id)
        {
            var categorieItem = await _context.CategorieItems.FindAsync(id);
            if (categorieItem == null)
            {
                return NotFound();
            }

            _context.CategorieItems.Remove(categorieItem);
            await _context.SaveChangesAsync();

            return categorieItem;
        }

        private bool CategorieItemExists(long id)
        {
            return _context.CategorieItems.Any(e => e.cat_id == id);
        }
    }
}
