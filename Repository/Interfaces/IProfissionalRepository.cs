using Consultorio.Models.Dtos;
using Consultorio.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Consultorio.Repository.Interfaces
{
    public interface IProfissionalRepository : IBaseRepository
    {
        Task<IEnumerable<ProfissionalDto>> GetAllProfissionaisAsync();
        Task<Profissional> GetProfissionalByIdAsync(int id);
        Task<ProfissionalEspecialidade> GetProfissionalEspecialidadeAsync(int profissionalId, int especialidadeId);
    }
}
