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
    public class LocationsController : ControllerBase
    {
        private readonly materialadministrationContext _context;

        public LocationsController(materialadministrationContext context)
        {
            _context = context;
        }

        // GET: api/Locations retorna las localizaciones con parametros de busqueda
        [HttpGet("Search")]
        public async Task<ActionResult<IEnumerable<Location>>> GetLocationsSearch(bool active, string search)
        {
            if (_context.Locations == null)
            {
                return NotFound();
            }
            return await _context.Locations.Where(u => u.Active == active  && (u.Name.Contains(search) || u.Description.Contains(search)) ).ToListAsync();
        }

        // GET: api/Locations retorna una lista completa de localizaciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Location>>> GetLocations(bool active)
        {
          if (_context.Locations == null)
          {
              return NotFound();
          }
            return await _context.Locations.Where(u => u.Active == active).ToListAsync();
        }

        // GET: api/Locations/5 retorna una localizacion segun un id
        [HttpGet("{id}")]
        public async Task<ActionResult<Location>> GetLocation(int id)
        {
          if (_context.Locations == null)
          {
              return NotFound();
          }
            var location = await _context.Locations.FindAsync(id);

            if (location == null)
            {
                return NotFound();
            }

            return location;
        }

        // PUT: api/Locations/5 actualiza una localizacion segun un id
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLocation(int id, LocationDTO location)
        {
            if (id != location.LocationId)
            {
                return BadRequest();
            }

            _context.Entry(location.getNativeModel()).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LocationExists(id))
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

        // POST: api/Locations crea una nueva localizacion
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Location>> PostLocation(LocationDTO location)
        {
          if (_context.Locations == null)
          {
              return Problem("Entity set 'materialadministrationContext.Locations'  is null.");
          }
            _context.Locations.Add(location.getNativeModel());
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLocation", new { id = location.LocationId }, location);
        }

        // DELETE: api/Locations/5 elimina una localizacion por id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLocation(int id)
        {
            if (_context.Locations == null)
            {
                return NotFound();
            }
            var location = await _context.Locations.FindAsync(id);
            if (location == null)
            {
                return NotFound();
            }

            _context.Locations.Remove(location);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LocationExists(int id)
        {
            return (_context.Locations?.Any(e => e.LocationId == id)).GetValueOrDefault();
        }
    }
}
