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
                    ObraSocial_Nombre = table.Column<string>(nullable: false),
                    ObraSocial_Sigla = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObrasSociales", x => x.ObraSocial_Id);
                    table.UniqueConstraint("AK_ObrasSociales_ObraSocial_Sigla", x => x.ObraSocial_Sigla);
                });

            migrationBuilder.CreateTable(
                name: "Pacientes",
                columns: table => new
                {
                    Paciente_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: false),
                    Apellido = table.Column<string>(nullable: false),
                    Fecha_Nacim = table.Column<DateTime>(nullable: false),
                    Sexo = table.Column<string>(nullable: false),
                    Domicilio = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Telefono = table.Column<string>(nullable: false),
                    Estado_Civil = table.Column<string>(nullable: false),
                    Nacionalidad = table.Column<string>(nullable: false),
                    ObraSocial_Id = table.Column<int>(nullable: false),
                    DNI = table.Column<string>(nullable: false),
                    Usuario_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacientes", x => x.Paciente_Id);
                    table.UniqueConstraint("AK_Pacientes_DNI_Usuario_Id", x => new { x.DNI, x.Usuario_Id });
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
                values: new object[] { 1, "White", "123", "Albuquerque, Nuevo Mexico", "walterwhite@mail.com", "casado", new DateTime(1959, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Estados Unidos", "Walter", 1, "masculino", "555-1258", 1 });

            migrationBuilder.InsertData(
                table: "Pacientes",
                columns: new[] { "Paciente_Id", "Apellido", "DNI", "Domicilio", "Email", "Estado_Civil", "Fecha_Nacim", "Nacionalidad", "Nombre", "ObraSocial_Id", "Sexo", "Telefono", "Usuario_Id" },
                values: new object[] { 2, "White", "1234", "4565st, Albuquerque, Nuevo Mexico", "skylerwhite@brba.com", "casada", new DateTime(1970, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Estados Unidos", "Skyler", 2, "femenino", "9999-8888", 2 });

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
