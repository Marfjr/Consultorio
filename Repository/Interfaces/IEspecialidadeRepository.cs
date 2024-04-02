using Consultorio.Models.Dtos;
using Consultorio.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Consultorio.Repository.Interfaces
{
    public interface IEspecialidadeRepository : IBaseRepository
    {
        Task<IEnumerable<EspecialidadeDto>> GetAllEspecialidadesAsync();
        Task<Especialidade> GetEspecialidadeByIdAsync(int id);
    }
}
