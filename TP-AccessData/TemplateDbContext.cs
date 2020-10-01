using Microsoft.EntityFrameworkCore;
using TP_AccessData.ModelConfigs;
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
            builder.ApplyConfiguration(new PacienteConfiguration());
            builder.ApplyConfiguration(new ObraSocialConfiguration());
        }
    }
}
