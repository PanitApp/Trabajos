using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Database.Entities
{
    public class Trabajo
    {
        public int Id { get; set; }
        [Required]
        public string NombreTrabajo { get; set; }
        public double Calificacion { get; set; }
        [Required]
        public string Estado { get; set; }
        public string Comentario { get; set; }
        [Required]
        public DateTime FechaEntrega { get; set; }
        [Required]
        public string Archivo { get; set; }
        [Required]
        public string EstudianteId { get; set; }
        [Required]
        public string PublicacionId { get; set; }
        public Trabajo() { }
    }
}
