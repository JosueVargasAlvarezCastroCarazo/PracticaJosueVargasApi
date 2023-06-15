using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PracticaJosueVargas.Models;
using PracticaJosueVargas.ModelsDTOs;

namespace PracticaJosueVargas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserConstructionsController : ControllerBase
    {
        private readonly materialadministrationContext _context;

        public UserConstructionsController(materialadministrationContext context)
        {
            _context = context;
        }

        // GET: api/UserConstructions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserConstruction>>> GetUserConstructions(int project)
        {
          if (_context.UserConstructions == null)
          {
              return NotFound();
          }
            return await _context.UserConstructions.Include(u => u.User).Where(u => u.ConstructionId == project).ToListAsync();
        }

        // GET: api/UserConstructions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserConstruction>> GetUserConstruction(int id)
        {
          if (_context.UserConstructions == null)
          {
              return NotFound();
          }
            var userConstruction = await _context.UserConstructions.FindAsync(id);

            if (userConstruction == null)
            {
                return NotFound();
            }

            return userConstruction;
        }

        // PUT: api/UserConstructions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserConstruction(int id, UserConstruction userConstruction)
        {
            if (id != userConstruction.UserConstructionId)
            {
                return BadRequest();
            }

            _context.Entry(userConstruction).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserConstructionExists(id))
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

        // POST: api/UserConstructions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserConstruction>> PostUserConstruction(UserConstructionDTO userConstruction)
        {
          if (_context.UserConstructions == null)
          {
              return Problem("Entity set 'materialadministrationContext.UserConstructions'  is null.");
          }

            if (_context.UserConstructions.Where(e => e.UserId == userConstruction.UserId && e.ConstructionId == userConstruction.ConstructionId).ToList().Count == 0)
            {
                _context.UserConstructions.Add(userConstruction.getNativeModel());
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetUserConstruction", new { id = userConstruction.UserConstructionId }, userConstruction);
            }
            else
            {
                return NoContent();
            }
 
        }

        // DELETE: api/UserConstructions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserConstruction(int id)
        {
            if (_context.UserConstructions == null)
            {
                return NotFound();
            }
            var userConstruction = await _context.UserConstructions.FindAsync(id);
            if (userConstruction == null)
            {
                return NotFound();
            }

            _context.UserConstructions.Remove(userConstruction);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserConstructionExists(int id)
        {
            return (_context.UserConstructions?.Any(e => e.UserConstructionId == id)).GetValueOrDefault();
        }
    }
}
