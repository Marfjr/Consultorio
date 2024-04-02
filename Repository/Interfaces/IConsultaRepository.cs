using Consultorio.Models.Dtos;
using Consultorio.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Consultorio.Repository.Interfaces
{
    public interface IConsultaRepository : IBaseRepository
    {
        Task<IEnumerable<Consulta>> GetAllConsultasAsync(ConsultaParams pparametros);
        Task<Consulta> GetConsultaByIdAsync(int id);
    }
}
