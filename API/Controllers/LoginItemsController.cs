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
    public class LoginItemsController : ControllerBase
    {
        private readonly LoginContext _context;

        public LoginItemsController(LoginContext context)
        {
            _context = context;
        }

        // GET: api/LoginItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LoginItem>>> GetLoginItems()
        {
            return await _context.LoginItems.ToListAsync();
        }

        // GET: api/LoginItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LoginItem>> GetLoginItem(long id)
        {
            var loginItem = await _context.LoginItems.FindAsync(id);

            if (loginItem == null)
            {
                return NotFound();
            }

            return loginItem;
        }

        // PUT: api/LoginItems/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLoginItem(long id, LoginItem loginItem)
        {
            if (id != loginItem.user_id)
            {
                return BadRequest();
            }

            _context.Entry(loginItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoginItemExists(id))
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

        // POST: api/LoginItems
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<LoginItem>> PostLoginItem(LoginItem loginItem)
        {
            _context.LoginItems.Add(loginItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLoginItem", new { id = loginItem.user_id }, loginItem);
        }

        // DELETE: api/LoginItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<LoginItem>> DeleteLoginItem(long id)
        {
            var loginItem = await _context.LoginItems.FindAsync(id);
            if (loginItem == null)
            {
                return NotFound();
            }

            _context.LoginItems.Remove(loginItem);
            await _context.SaveChangesAsync();

            return loginItem;
        }

        private bool LoginItemExists(long id)
        {
            return _context.LoginItems.Any(e => e.user_id == id);
        }
    }
}
