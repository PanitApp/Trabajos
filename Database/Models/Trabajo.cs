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
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public int Id { get; set; }
        public string NombreTrabajo { get; set; }
        public double Calificacion { get; set; }
        public string Estado { get; set; }
        public string Comentario { get; set; }
        public DateTime FechaEntrega { get; set; }
        public string Archivo { get; set; }
        public string EstudianteId { get; set; }
        public string PublicacionId { get; set; }
        public Trabajo() { }
    }
}
