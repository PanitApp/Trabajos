using Microsoft.EntityFrameworkCore;
using WebApplication1.Controllers;
using WebApplication1.Database.Entities;

namespace WebApplication1.Database
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }
        public DbSet<Trabajo> Trabajos { get; set; }
        public DbSet<Publicacion> Publicaciones { get; set; }

    }
}
