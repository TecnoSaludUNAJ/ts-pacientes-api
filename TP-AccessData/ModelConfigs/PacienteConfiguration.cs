using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using TP_Domain.Entities;

namespace TP_AccessData.ModelConfigs
{
    public class PacienteConfiguration : IEntityTypeConfiguration<Paciente>
    {
        public void Configure(EntityTypeBuilder<Paciente> builder)
        {
            // PK
            builder.HasKey(p => p.Paciente_Id);
            // FK
            builder.HasOne<ObraSocial>(p => p.ObraSocial)
                .WithMany(o => o.Pacientes)
                .HasForeignKey(p => p.ObraSocial_Id);
            // set not null
            builder.Property(p => p.Apellido).IsRequired();
            builder.Property(p => p.DNI).IsRequired();
            builder.Property(p => p.Domicilio).IsRequired();
            builder.Property(p => p.Email).IsRequired();
            builder.Property(p => p.Estado_Civil).IsRequired();
            builder.Property(p => p.Fecha_Nacim).IsRequired();
            builder.Property(p => p.Nacionalidad).IsRequired();
            builder.Property(p => p.Nombre).IsRequired();
            builder.Property(p => p.ObraSocial_Id).IsRequired();
            builder.Property(p => p.Sexo).IsRequired();
            builder.Property(p => p.Telefono).IsRequired();

            builder.HasAlternateKey(p => new { p.DNI, p.Usuario_Id });

            // PRELOAD Paciente
            builder.HasData(
                new Paciente
                {
                    Apellido = "White",
                    DNI = 12545467,
                    Domicilio = "Albuquerque, Nuevo Mexico",
                    Email = "walterwhite@mail.com",
                    Estado_Civil = "casado",
                    Fecha_Nacim = new DateTime(1959, 9, 7),
                    Nacionalidad = "Estados Unidos",
                    Nombre = "Walter",
                    ObraSocial_Id = 1,
                    Paciente_Id = 1,
                    Sexo = "masculino",
                    Telefono = "555-1258",
                    Usuario_Id = 1
                }
                );
            builder.HasData(
                new Paciente
                {
                    Apellido = "White",
                    DNI = 891011234,
                    Domicilio = "4565st, Albuquerque, Nuevo Mexico",
                    Email = "skylerwhite@brba.com",
                    Estado_Civil = "casada",
                    Fecha_Nacim = new DateTime(1970, 8, 11),
                    Nacionalidad = "Estados Unidos",
                    Nombre = "Skyler",
                    ObraSocial_Id = 2,
                    Paciente_Id = 2,
                    Sexo = "femenino", 
                    Telefono = "9999-8888",
                    Usuario_Id = 2
                }
                );

        }
    }
}
