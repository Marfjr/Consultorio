using Consultorio.Context;
using Consultorio.Models.Dtos;
using Consultorio.Models.Entities;
using Consultorio.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Consultorio.Repository
{
    public class ConsultaRepository : BaseRepository, IConsultaRepository
    {
        private readonly ConsultorioContext _context;
        public ConsultaRepository(ConsultorioContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Consulta>> GetAllConsultasAsync(ConsultaParams parametros)
        {
            var consultas = _context.Consultas
                .Include(c => c.Paciente)
                .Include(c => c.Profissional)
                .Include(c => c.Especialidade).AsQueryable();

            DateTime dataVazia = new DateTime();

            if (parametros.DataInicio != dataVazia) consultas = consultas.Where(c => c.DataHorario >= parametros.DataInicio);

            if (parametros.DataFim != dataVazia) consultas = consultas.Where(c => c.DataHorario <= parametros.DataFim);

            if(!string.IsNullOrEmpty(parametros.NomeEspecialidade))
            {
                string nomeEspecialidade = parametros.NomeEspecialidade.ToLower().Trim();
                consultas = consultas.Where(c => c.Especialidade.Nome.ToLower().Contains(nomeEspecialidade));
            }
            
            return await consultas.ToListAsync();            
        }

        public async Task<Consulta> GetConsultaByIdAsync(int id)
        {
            return await _context.Consultas
             .Include(c => c.Paciente)
             .Include(c => c.Profissional)
             .Include(c => c.Especialidade)
             .Where(c => c.Id == id)
             .FirstOrDefaultAsync();
        }
    }
}
