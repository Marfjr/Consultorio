using Consultorio.Map;
using Consultorio.Models.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Consultorio.Maps
{
    public class EspecialidadeMap : BaseMap<Especialidade>
    {
        public EspecialidadeMap() : base("Especialidade")
        { }

        public override void Configure(EntityTypeBuilder<Especialidade> builder)
        {
            base.Configure(builder);
     
        }
    }
}
