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
    public class PublicacionController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public PublicacionController(DatabaseContext context)
        {
            _context = context;

        }
        // GET: api/<PublicacionController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Publicacion>>> GetPublicaciones()
        {
            return await _context.Publicaciones.ToListAsync();
        }

        // GET api/<PublicacionController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Publicacion>> GetPublicacion(int id)
        {
            var publicacion = await _context.Publicaciones.FindAsync(id);

            if(publicacion == null)
            {
                return NotFound();
            }

            return publicacion;
        }

        // GET api/<PublicacionController>/curso/5
        [HttpGet("curso/{id}")]
        public async Task<ActionResult<IEnumerable<Publicacion>>> GetPublicacionByCursoId(string id)
        {   
            return await _context.Publicaciones.
            Select(x => new Publicacion{
                Id = x.Id,
                Descripcion = x.Descripcion,
                FechaPublicacion = x.FechaPublicacion,
                Archivos = x.Archivos,
                CursoId = x.CursoId
            }).Where(x => x.CursoId == id).ToListAsync();
        }

        // POST api/<PublicacionController>
        [HttpPost]
        public async Task<ActionResult<Publicacion>> PostPublicacion(Publicacion publicacion)
        {
            _context.Publicaciones.Add(publicacion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPublicacion", new { id = publicacion.Id}, publicacion);
        }

        // PUT api/<PublicacionController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> PutPublicacion(int id, Publicacion publicacion)
        {
            if (id != publicacion.Id)
            {
                return BadRequest();
            }

            _context.Entry(publicacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch
            {
                if (!PublicacionExists(id))
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

        // DELETE api/<PublicacionController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Publicacion>> DeletePublicacion(int id)
        {
            var publicacion = await _context.Publicaciones.FindAsync(id);

            if(publicacion == null)
            {
                return NotFound();
            }

            _context.Publicaciones.Remove(publicacion);
            await _context.SaveChangesAsync();

            return publicacion;
        }

        private bool PublicacionExists(int id)
        {
            return _context.Publicaciones.Any(e => e.Id == id);
        }
    }
}
