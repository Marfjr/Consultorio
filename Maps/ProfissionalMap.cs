using Consultorio.Map;
using Consultorio.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Consultorio.Maps
{
    public class ProfissionalMap : BaseMap<Profissional>
    {
        public ProfissionalMap() : base("Profissional")
        { }

        public override void Configure(EntityTypeBuilder<Profissional> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Nome).IsRequired();
            builder.HasMany(x => x.Especialidades)
                .WithMany(x => x.Profissionais)
                .UsingEntity<ProfissionalEspecialidade>(
                    x => x.HasOne(p => p.Especialidade).WithMany().HasForeignKey(x => x.EspecialidadeId),
                    x => x.HasOne(p => p.Profissionais).WithMany().HasForeignKey(x => x.ProfissionalId),
                    x =>
                    {
                        x.ToTable("ProfissionalEspecialidade");

                        x.HasKey(p => new { p.EspecialidadeId, p.ProfissionalId });

                        x.Property(p => p.EspecialidadeId).IsRequired();
                        x.Property(p => p.ProfissionalId).IsRequired();
                    }
                ); ;
        }
    }
}
