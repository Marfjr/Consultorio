using Consultorio.Map;
using Consultorio.Models.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Consultorio.Maps
{
    public class ConsultaMap : BaseMap<Consulta>
    {
        public ConsultaMap() : base("Consulta")
        { }

        public override void Configure(EntityTypeBuilder<Consulta> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.PacienteId).IsRequired();
            builder.HasOne(x => x.Paciente).WithMany(x => x.Consultas).HasForeignKey(x => x.PacienteId);

            builder.Property(x => x.ProfissionalId).IsRequired();
            builder.HasOne(x => x.Profissional).WithMany(x => x.Consultas).HasForeignKey(x => x.ProfissionalId);

            builder.Property(x => x.EspecialidadeId).IsRequired();
            builder.HasOne(x => x.Especialidade).WithMany(x => x.Consultas).HasForeignKey(x => x.EspecialidadeId);

        }
    }
}