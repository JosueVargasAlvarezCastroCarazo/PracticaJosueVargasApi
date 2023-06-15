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
    //[ApiKey]
    public class ProjectsController : ControllerBase
    {
        private readonly materialadministrationContext _context;

        public ProjectsController(materialadministrationContext context)
        {
            _context = context;
        }

        // GET: api/Projects
        [HttpGet("Search")]
        public ActionResult<IEnumerable<Project>> GetProjectsSearch(bool active, string search, bool admin, int user)
        {
            if (_context.Projects == null)
            {
                return NotFound();
            }

            if (admin)
            {
                return _context.Projects.Include(u => u.User).Where(u => u.Active == active && (u.Name.Contains(search) || u.Description.Contains(search))).ToList();
            }

            var userProjectsList = _context.UserConstructions.Include(u => u.Construction.User).Where(u => u.UserId == user && u.Construction.Active == active && (u.Construction.Name.Contains(search) || u.Construction.Description.Contains(search))).ToList();

            var projects = new List<Project>();

            foreach (var userProject in userProjectsList)
            {
                projects.Add(userProject.Construction);
            }

            return projects;
        }

        // GET: api/Projects
        [HttpGet]
        public ActionResult<IEnumerable<Project>> GetProjects(bool active,bool admin,int user)
        {
          if (_context.Projects == null)
          {
              return NotFound();
          }

            if (admin)
            {
                return _context.Projects.Include(u => u.User).Where(u => u.Active == active).ToList();
            }

            var userProjectsList = _context.UserConstructions.Include(u => u.Construction.User).Where(u => u.UserId == user && u.Construction.Active == active).ToList();

            var projects = new List<Project>();

            foreach (var userProject in userProjectsList)
            {
                projects.Add(userProject.Construction);
            }

            return projects;


        }

        // GET: api/Projects/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Project>> GetProject(int id)
        {
          if (_context.Projects == null)
          {
              return NotFound();
          }
            var project = await _context.Projects.FindAsync(id);

            if (project == null)
            {
                return NotFound();
            }

            return project;
        }

        // PUT: api/Projects/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProject(int id, ProjectDTO project)
        {
            if (id != project.ProjectId)
            {
                return BadRequest();
            }

            _context.Entry(project.getNativeModel()).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectExists(id))
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

        // POST: api/Projects
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Project>> PostProject(ProjectDTO project)
        {
          if (_context.Projects == null)
          {
              return Problem("Entity set 'materialadministrationContext.Projects'  is null.");
          }
            _context.Projects.Add(project.getNativeModel());
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProject", new { id = project.ProjectId }, project);
        }

        // DELETE: api/Projects/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProject(int id)
        {
            if (_context.Projects == null)
            {
                return NotFound();
            }
            var project = await _context.Projects.FindAsync(id);
            if (project == null)
            {
                return NotFound();
            }

            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProjectExists(int id)
        {
            return (_context.Projects?.Any(e => e.ProjectId == id)).GetValueOrDefault();
        }
    }
}
