using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TP_Domain.Entities;

namespace TP_AccessData.ModelConfigs
{
    public class ObraSocialConfiguration : IEntityTypeConfiguration<ObraSocial>
    {
        public void Configure(EntityTypeBuilder<ObraSocial> builder)
        {
            // PK
            builder.HasKey(o => o.ObraSocial_Id);
            // set not null
            builder.Property(o => o.ObraSocial_Nombre).IsRequired();
            builder.Property(o => o.ObraSocial_Sigla).IsRequired().HasMaxLength(20);

            // LOAD ObraSocial DATA
            builder.HasData(
                new ObraSocial
                {
                    ObraSocial_Id = 1,
                    ObraSocial_Nombre = "O.S. de Empresarios Profesionales y Monotributistas",
                    ObraSocial_Sigla = "OSDEPYM"
                }
                );
            builder.HasData(
                new ObraSocial
                {
                    ObraSocial_Id = 2,
                    ObraSocial_Nombre = "O.S. de los Empleados de Comercio y Actividades Civiles",
                    ObraSocial_Sigla = "OSECAC"
                }
                );

        }
    }
}
