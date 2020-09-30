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
                    ObraSocial_Nombre = table.Column<string>(nullable: true),
                    ObraSocial_Sigla = table.Column<string>(nullable: true)
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
                    Usuario_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacientes", x => x.Paciente_Id);
                    table.ForeignKey(
                        name: "FK_Pacientes_ObrasSociales_ObraSocial_Id",
                        column: x => x.ObraSocial_Id,
                        principalTable: "ObrasSociales",
                        principalColumn: "ObraSocial_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ObrasSociales",
                columns: new[] { "ObraSocial_Id", "ObraSocial_Nombre", "ObraSocial_Sigla" },
                values: new object[] { 1, "O.S. de Empresarios Profesionales y Monotributistas", "OSDEPYM" });

            migrationBuilder.InsertData(
                table: "ObrasSociales",
                columns: new[] { "ObraSocial_Id", "ObraSocial_Nombre", "ObraSocial_Sigla" },
                values: new object[] { 2, "O.S. de los Empleados de Comercio y Actividades Civiles", "OSECAC" });

            migrationBuilder.InsertData(
                table: "Pacientes",
                columns: new[] { "Paciente_Id", "Apellido", "DNI", "Domicilio", "Email", "Estado_Civil", "Fecha_Nacim", "Nacionalidad", "Nombre", "ObraSocial_Id", "Sexo", "Telefono", "Usuario_Id" },
                values: new object[] { 1, "Doe", 40000000, "Calle Falsa 123, Springfield", "johndoe@mail.com", "Soltero", new DateTime(1997, 7, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "argentina", "John", 1, "masculino", "1234-4566", 1 });

            migrationBuilder.InsertData(
                table: "Pacientes",
                columns: new[] { "Paciente_Id", "Apellido", "DNI", "Domicilio", "Email", "Estado_Civil", "Fecha_Nacim", "Nacionalidad", "Nombre", "ObraSocial_Id", "Sexo", "Telefono", "Usuario_Id" },
                values: new object[] { 2, "Doe", 40000000, "Cochabamba 1614, segundo piso, corredor cuatro", "janedoe@mail.com", "soltero", new DateTime(1998, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "argentina", "Jane", 1, "femenino", "7777-4566", 2 });

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_ObraSocial_Id",
                table: "Pacientes",
                column: "ObraSocial_Id");
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
