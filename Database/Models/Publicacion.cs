using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    public class Publicacion
    {
        public int Id { get; set; }
        [Required]
        public string Descripcion { get; set; }
        [Required]
        public DateTime FechaPublicacion { get; set; }
        [Required]
        public string Archivos { get; set; }
        [Required]
        public string CursoId { get; set; }
        public Publicacion() { }
    }
}
