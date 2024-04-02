using Consultorio.Context;
using Consultorio.Models.Dtos;
using Consultorio.Models.Entities;
using Consultorio.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Consultorio.Repository
{
    public class PacienteRepository : BaseRepository, IPacienteRepository
    {
        private readonly ConsultorioContext _context;

        public PacienteRepository(ConsultorioContext context) : base(context)
        {
            _context = context;
        }
        public async Task<IEnumerable<PacienteDto>> GetAllPacientesAsync()
        {
            return await _context.Pacientes
                        .Select(x => new PacienteDto { Id = x.Id, Nome = x.Nome })
                        .ToListAsync();
        }

        public async Task<Paciente> GetPacienteByIdAsync(int id)
        {
            return await _context.Pacientes.Include(x => x.Consultas)
             .ThenInclude(c => c.Especialidade)
                .ThenInclude(c => c.Profissionais)
                    .Where(x => x.Id == id).FirstOrDefaultAsync();

        }
    }
}
