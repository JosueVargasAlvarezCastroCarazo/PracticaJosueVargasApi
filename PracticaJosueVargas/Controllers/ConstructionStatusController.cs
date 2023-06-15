using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PracticaJosueVargas.Attributes;
using PracticaJosueVargas.Models;

namespace PracticaJosueVargas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiKey]
    public class ConstructionStatusController : ControllerBase
    {
        private readonly materialadministrationContext _context;

        public ConstructionStatusController(materialadministrationContext context)
        {
            _context = context;
        }

        // GET: api/ConstructionStatus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ConstructionStatus>>> GetConstructionStatuses()
        {
          if (_context.ConstructionStatuses == null)
          {
              return NotFound();
          }
            return await _context.ConstructionStatuses.Where(u => u.Active == true).ToListAsync();
        }

        // GET: api/ConstructionStatus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ConstructionStatus>> GetConstructionStatus(int id)
        {
          if (_context.ConstructionStatuses == null)
          {
              return NotFound();
          }
            var constructionStatus = await _context.ConstructionStatuses.FindAsync(id);

            if (constructionStatus == null)
            {
                return NotFound();
            }

            return constructionStatus;
        }

        // PUT: api/ConstructionStatus/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConstructionStatus(int id, ConstructionStatus constructionStatus)
        {
            if (id != constructionStatus.ConstructionStatusId)
            {
                return BadRequest();
            }

            _context.Entry(constructionStatus).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConstructionStatusExists(id))
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

        // POST: api/ConstructionStatus
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ConstructionStatus>> PostConstructionStatus(ConstructionStatus constructionStatus)
        {
          if (_context.ConstructionStatuses == null)
          {
              return Problem("Entity set 'materialadministrationContext.ConstructionStatuses'  is null.");
          }
            _context.ConstructionStatuses.Add(constructionStatus);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetConstructionStatus", new { id = constructionStatus.ConstructionStatusId }, constructionStatus);
        }

        // DELETE: api/ConstructionStatus/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConstructionStatus(int id)
        {
            if (_context.ConstructionStatuses == null)
            {
                return NotFound();
            }
            var constructionStatus = await _context.ConstructionStatuses.FindAsync(id);
            if (constructionStatus == null)
            {
                return NotFound();
            }

            _context.ConstructionStatuses.Remove(constructionStatus);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ConstructionStatusExists(int id)
        {
            return (_context.ConstructionStatuses?.Any(e => e.ConstructionStatusId == id)).GetValueOrDefault();
        }
    }
}
