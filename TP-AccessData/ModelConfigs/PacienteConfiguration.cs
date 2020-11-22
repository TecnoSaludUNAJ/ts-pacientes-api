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

        }
    }
}
