using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Database;
using WebApplication1.Database.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrabajoController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public TrabajoController(DatabaseContext context)
        {
            _context = context;

        }
        // GET: api/<TrabajoController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Trabajo>>> GetTrabajo() 
        {
            return await _context.Trabajos.ToListAsync();
        }

        // GET api/<TrabajoController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Trabajo>> GetTrabajo(int id)
        {
            var trabajo = await _context.Trabajos.FindAsync(id);

            if(trabajo == null)
            {
                return NotFound();
            }

            return trabajo;
        }

        // POST api/<TrabajoController>
        [HttpPost]
        public async Task<ActionResult<Trabajo>> PostTrabajo(Trabajo trabajo)
        {
            _context.Trabajos.Add(trabajo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTrabajo", new {id = trabajo.Id }, trabajo);
        }

        // PUT api/<TrabajoController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> PutTrabajo(int id, Trabajo trabajo)
        {
            if(id != trabajo.Id)
            {
                return BadRequest();
            }

            _context.Entry(trabajo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch
            {
                if(!TrabajoExists(id))
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

        // DELETE api/<TrabajoController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Trabajo>> DeleteTrabajo(int id)
        {
            var trabajo = await _context.Trabajos.FindAsync(id);

            if (trabajo == null)
            {
                return NotFound();
            }

            _context.Trabajos.Remove(trabajo);
            await _context.SaveChangesAsync();

            return trabajo;
        }

        private bool TrabajoExists(int id)
        {
            return _context.Trabajos.Any(e => e.Id == id);
        }
    }
}
