using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TP_Domain.Entities;

namespace TP_AccessData
{
    public class TemplateDbContext : DbContext
    {
        public TemplateDbContext(DbContextOptions<TemplateDbContext> options) : base(options)
        {

        }

        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<ObraSocial> ObrasSociales { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // LOAD ObraSocial DATA
            builder.Entity<ObraSocial>().HasData(
                new ObraSocial
                {
                    ObraSocial_Id = 1,
                    ObraSocial_Nombre = "O.S. de Empresarios Profesionales y Monotributistas",
                    ObraSocial_Sigla = "OSDEPYM"
                }
                );
            builder.Entity<ObraSocial>().HasData(
                new ObraSocial
                {
                    ObraSocial_Id = 2,
                    ObraSocial_Nombre = "O.S. de los Empleados de Comercio y Actividades Civiles",
                    ObraSocial_Sigla = "OSECAC"
                }
                );
            // LOAD Paciente DATA
            builder.Entity<Paciente>().HasData(
                new Paciente
                {
                    Apellido = "Doe",
                    DNI = 40000000,
                    Domicilio = "Calle Falsa 123, Springfield",
                    Email = "johndoe@mail.com",
                    Estado_Civil = "Soltero",
                    Fecha_Nacim = new DateTime(1997,7, 19),
                    Nacionalidad = "argentina",
                    Nombre = "John",
                    ObraSocial_Id = 1,
                    Paciente_Id = 1,
                    Sexo = "masculino",
                    Telefono = "1234-4566",
                    Usuario_Id = 1
                }
                );
            builder.Entity<Paciente>().HasData(
                new Paciente
                {
                    Apellido = "Doe",
                    DNI = 40000000,
                    Domicilio = "Cochabamba 1614, segundo piso, corredor cuatro",
                    Email = "janedoe@mail.com",
                    Estado_Civil = "soltero",
                    Fecha_Nacim = new DateTime(1998, 8, 18),
                    Nacionalidad = "argentina",
                    Nombre = "Jane",
                    ObraSocial_Id = 1,
                    Paciente_Id = 2,
                    Sexo = "femenino",
                    Telefono = "7777-4566",
                    Usuario_Id = 2
                }
                );
        }
    }
}
