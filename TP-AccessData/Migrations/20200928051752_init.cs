using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TP_AccessData.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ObrasSociales",
                columns: table => new
                {
                    ObraSocial_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ObraSocial_Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObrasSociales", x => x.ObraSocial_Id);
                });

            migrationBuilder.CreateTable(
                name: "Pacientes",
                columns: table => new
                {
                    Paciente_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true),
                    Apellido = table.Column<string>(nullable: true),
                    Fecha_Nacim = table.Column<DateTime>(nullable: false),
                    Sexo = table.Column<string>(nullable: true),
                    Domicilio = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Telefono = table.Column<string>(nullable: true),
                    Estado_Civil = table.Column<string>(nullable: true),
                    Nacionalidad = table.Column<string>(nullable: true),
                    ObraSocial_Id = table.Column<int>(nullable: false),
                    DNI = table.Column<int>(nullable: false),
                    Usuario_Id = table.Column<int>(nullable: false),
                    ObraSocial_Id1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacientes", x => x.Paciente_Id);
                    table.ForeignKey(
                        name: "FK_Pacientes_ObrasSociales_ObraSocial_Id1",
                        column: x => x.ObraSocial_Id1,
                        principalTable: "ObrasSociales",
                        principalColumn: "ObraSocial_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_ObraSocial_Id1",
                table: "Pacientes",
                column: "ObraSocial_Id1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pacientes");

            migrationBuilder.DropTable(
                name: "ObrasSociales");
        }
    }
}
