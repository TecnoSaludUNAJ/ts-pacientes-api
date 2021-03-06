﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TP_AccessData.Migrations
{
    public partial class initial : Migration
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
