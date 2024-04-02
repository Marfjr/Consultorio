using Consultorio.Map;
using Consultorio.Models.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Consultorio.Maps
{
    public class PacienteMap : BaseMap<Paciente>
    {
        public PacienteMap() : base("Paciente")
        { }

        public override void Configure(EntityTypeBuilder<Paciente> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.Nome).IsRequired();
        }
    }
}
