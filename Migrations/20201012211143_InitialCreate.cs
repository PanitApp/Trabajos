using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Publicaciones",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(nullable: false),
                    FechaPublicacion = table.Column<DateTime>(nullable: false),
                    Archivos = table.Column<string>(nullable: false),
                    CursoId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publicaciones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Trabajos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreTrabajo = table.Column<string>(nullable: false),
                    Calificacion = table.Column<double>(nullable: false),
                    Estado = table.Column<string>(nullable: false),
                    Comentario = table.Column<string>(nullable: true),
                    FechaEntrega = table.Column<DateTime>(nullable: false),
                    Archivo = table.Column<string>(nullable: false),
                    EstudianteId = table.Column<string>(nullable: false),
                    PublicacionId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trabajos", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Publicaciones");

            migrationBuilder.DropTable(
                name: "Trabajos");
        }
    }
}
