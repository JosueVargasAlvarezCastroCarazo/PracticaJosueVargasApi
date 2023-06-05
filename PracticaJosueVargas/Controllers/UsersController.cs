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
using PracticaJosueVargas.Tools;

namespace PracticaJosueVargas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiKey]
    public class UsersController : ControllerBase
    {
        private readonly materialadministrationContext _context;

        public UsersController(materialadministrationContext context)
        {
            _context = context;
        }

        //filtra la lista de usuarios
        [HttpGet("Search")]
        public ActionResult<IEnumerable<UserDTO>> GetUsersSearch(bool active, string search)
        {

            var query = (
                  from u in _context.Users
                  where u.Active == active && (u.Name.Contains(search) || u.Identification.Contains(search) || u.Email.Contains(search))
                  select new UserDTO(
                      u.UserId,
                      u.Identification,
                      u.Email,
                      u.Name,
                      u.PhoneNumber,
                      u.Address,
                      u.Password,
                      u.Active,
                      u.UserRolId)
                  ).ToList();

            return query;
        }

        // GET: api/Users
        [HttpGet]
        public ActionResult<IEnumerable<UserDTO>> GetUsers(bool active)
        {
            if (_context.Users == null)
            {
                return NotFound();
            }

            var query = (
                    from u in _context.Users
                    where u.Active == active
                    select new UserDTO(
                        u.UserId,
                        u.Identification,
                        u.Email,
                        u.Name,
                        u.PhoneNumber,
                        u.Address,
                        u.Password,
                        u.Active,
                        u.UserRolId)
                    ).ToList();

            return query;
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> GetUser(int id)
        {
          if (_context.Users == null)
          {
              return NotFound();
          }
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return new UserDTO(user);
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, UserDTO user)
        {
            if (id != user.UserId)
            {
                return BadRequest();
            }

            _context.Entry(user.getNativeModel()).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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

        //actualiza un usaurio, ademas encripta la contraseña porque fue que se cambio
        [HttpPut("password/{id}")]
        public async Task<IActionResult> PutUserChangePassword(int id, UserDTO user)
        {

            String EncriptedPassword = new Crypto().EncriptarEnUnSentido(user.Password);
            user.Password = EncriptedPassword;

            if (id != user.UserId)
            {
                return BadRequest();
            }

            _context.Entry(user.getNativeModel()).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(UserDTO user)
        {
          if (_context.Users == null)
          {
              return Problem("Entity set 'materialadministrationContext.Users'  is null.");
          }

            String EncriptedPassword = new Crypto().EncriptarEnUnSentido(user.Password);
            user.Password = EncriptedPassword;

            _context.Users.Add(user.getNativeModel());
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.UserId }, user);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            if (_context.Users == null)
            {
                return NotFound();
            }
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return (_context.Users?.Any(e => e.UserId == id)).GetValueOrDefault();
        }


        //devuelve un usurio segun identificacion y contra
        [HttpGet("LoginUser")]
        //this use query string
        public async Task<ActionResult<UserDTO>> LoginUser(string identification, string password)
        {

            String EncriptedPassword = new Crypto().EncriptarEnUnSentido(password);

            User? user = await _context.Users.SingleOrDefaultAsync(e => e.Identification == identification && e.Password == EncriptedPassword);

            if (user == null)
            {
                return NotFound();
            }

            return new UserDTO(user);
        }

        [HttpGet("CheckIdentification")]
        //devuelve un usuario segun una identificacion
        //this use query string
        public async Task<ActionResult<UserDTO>> CheckIdentification(string identification)
        {

            User? user = await _context.Users.SingleOrDefaultAsync(e => e.Identification == identification);

            if (user == null)
            {
                return NotFound();
            }

            return new UserDTO(user);
        }
    }
}
