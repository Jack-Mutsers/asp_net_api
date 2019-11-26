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
    public class ValidationItemsController : ControllerBase
    {
        private readonly ValidationContext _context;

        public ValidationItemsController(ValidationContext context)
        {
            _context = context;
        }

        // GET: api/ValidationItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ValidationItem>>> GetValidationItems()
        {
            return await _context.ValidationItems.ToListAsync();
        }

        // GET: api/ValidationItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ValidationItem>> GetValidationItem(string id)
        {
            var validationItem = await _context.ValidationItems.FindAsync(id);

            if (validationItem == null)
            {
                return NotFound();
            }

            return validationItem;
        }

        // PUT: api/ValidationItems/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutValidationItem(string id, ValidationItem validationItem)
        {
            if (id != validationItem.access_token)
            {
                return BadRequest();
            }

            _context.Entry(validationItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ValidationItemExists(id))
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

        // POST: api/ValidationItems
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<ValidationItem>> PostValidationItem(ValidationItem validationItem)
        {
            _context.ValidationItems.Add(validationItem);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ValidationItemExists(validationItem.access_token))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetValidationItem", new { id = validationItem.access_token }, validationItem);
        }

        // DELETE: api/ValidationItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ValidationItem>> DeleteValidationItem(string id)
        {
            var validationItem = await _context.ValidationItems.FindAsync(id);
            if (validationItem == null)
            {
                return NotFound();
            }

            _context.ValidationItems.Remove(validationItem);
            await _context.SaveChangesAsync();

            return validationItem;
        }

        private bool ValidationItemExists(string id)
        {
            return _context.ValidationItems.Any(e => e.access_token == id);
        }
    }
}
