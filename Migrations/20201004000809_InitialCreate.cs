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
                    Id = table.Column<int>(nullable: false),
                    Descripcion = table.Column<string>(nullable: true),
                    FechaPublicacion = table.Column<DateTime>(nullable: false),
                    Archivos = table.Column<string>(nullable: true),
                    CursoId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publicaciones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Trabajos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    NombreTrabajo = table.Column<string>(nullable: true),
                    Calificacion = table.Column<double>(nullable: false),
                    Estado = table.Column<string>(nullable: true),
                    Comentario = table.Column<string>(nullable: true),
                    FechaEntrega = table.Column<DateTime>(nullable: false),
                    Archivo = table.Column<string>(nullable: true),
                    EstudianteId = table.Column<string>(nullable: true),
                    PublicacionId = table.Column<string>(nullable: true)
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
