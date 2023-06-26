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
    public class MaterialsController : ControllerBase
    {
        private readonly materialadministrationContext _context;

        public MaterialsController(materialadministrationContext context)
        {
            _context = context;
        }

        // GET: api/Materials retorna una lista de materiales con parametros de busqueda y proyecto
        [HttpGet("Search")]
        public async Task<ActionResult<IEnumerable<Material>>> GetMaterialsSearch(bool active, int project, string search)
        {
            if (_context.Materials == null)
            {
                return NotFound();
            }
            return await _context.Materials.Include(u => u.Location).Where(u => u.Active == active && u.ProjectId == project && (u.Name.Contains(search) || u.Description.Contains(search))).ToListAsync();
        }

        // GET: api/Materials retorna una lista de materiales de un proyecto
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Material>>> GetMaterials(bool active, int project)
        {
          if (_context.Materials == null)
          {
              return NotFound();
          }
            return await _context.Materials.Include(u => u.Location).Where(u => u.Active == active && u.ProjectId == project).ToListAsync();
        }

        // GET: api/Materials/5 retorna un material segun un id
        [HttpGet("{id}")]
        public async Task<ActionResult<Material>> GetMaterial(int id)
        {
          if (_context.Materials == null)
          {
              return NotFound();
          }
            var material = await _context.Materials.FindAsync(id);

            if (material == null)
            {
                return NotFound();
            }

            return material;
        }

        // PUT: api/Materials/5 actualiza un material por id
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMaterial(int id, MaterialDTO material)
        {
            if (id != material.MaterialId)
            {
                return BadRequest();
            }

            _context.Entry(material.getNativeModel()).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MaterialExists(id))
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

        // POST: api/Materials crea un nuevo material
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Material>> PostMaterial(MaterialDTO material)
        {
          if (_context.Materials == null)
          {
              return Problem("Entity set 'materialadministrationContext.Materials'  is null.");
          }
            _context.Materials.Add(material.getNativeModel());
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMaterial", new { id = material.MaterialId }, material);
        }

        // DELETE: api/Materials/5 elimina una meterial por id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMaterial(int id)
        {
            if (_context.Materials == null)
            {
                return NotFound();
            }
            var material = await _context.Materials.FindAsync(id);
            if (material == null)
            {
                return NotFound();
            }

            _context.Materials.Remove(material);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MaterialExists(int id)
        {
            return (_context.Materials?.Any(e => e.MaterialId == id)).GetValueOrDefault();
        }
    }
}
