using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PracticaJosueVargas.Attributes;
using PracticaJosueVargas.Models;
using PracticaJosueVargas.ModelsDTOs;

namespace PracticaJosueVargas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiKey]
    public class UserRolsController : ControllerBase
    {
        private readonly materialadministrationContext _context;

        public UserRolsController(materialadministrationContext context)
        {
            _context = context;
        }

        // GET: api/UserRols
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserRol>>> GetUserRols()
        {
          if (_context.UserRols == null)
          {
              return NotFound();
          }
            return await _context.UserRols.Where(u => u.Active == true).ToListAsync();
        }

        // GET: api/UserRols/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserRol>> GetUserRol(int id)
        {
          if (_context.UserRols == null)
          {
              return NotFound();
          }
            var userRol = await _context.UserRols.FindAsync(id);

            if (userRol == null)
            {
                return NotFound();
            }

            return userRol;
        }

        // PUT: api/UserRols/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserRol(int id, UserRol userRol)
        {
            if (id != userRol.UserRolId)
            {
                return BadRequest();
            }

            _context.Entry(userRol).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserRolExists(id))
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

        // POST: api/UserRols
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserRol>> PostUserRol(UserRol userRol)
        {
          if (_context.UserRols == null)
          {
              return Problem("Entity set 'materialadministrationContext.UserRols'  is null.");
          }
            _context.UserRols.Add(userRol);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserRol", new { id = userRol.UserRolId }, userRol);
        }

        // DELETE: api/UserRols/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserRol(int id)
        {
            if (_context.UserRols == null)
            {
                return NotFound();
            }
            var userRol = await _context.UserRols.FindAsync(id);
            if (userRol == null)
            {
                return NotFound();
            }

            _context.UserRols.Remove(userRol);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserRolExists(int id)
        {
            return (_context.UserRols?.Any(e => e.UserRolId == id)).GetValueOrDefault();
        }
    }
}
