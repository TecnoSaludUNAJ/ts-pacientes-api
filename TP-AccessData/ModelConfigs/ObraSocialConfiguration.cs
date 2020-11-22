using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
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

            builder.HasAlternateKey(o => o.ObraSocial_Sigla);

        }
    }
}
