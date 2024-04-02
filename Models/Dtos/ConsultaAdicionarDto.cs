using Consultorio.Models.Entities;
using System;

namespace Consultorio.Models.Dtos
{
    public class ConsultaAdicionarDto
    {
        public DateTime DataHorario { get; set; }
        public int Status { get; set; }
        public decimal Preco { get; set; }
        public int PacienteId { get; set; }
        public int EspecialidadeId { get; set; }
        public int ProfissionalId { get; set; }
    }
}
