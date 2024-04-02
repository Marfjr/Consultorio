using System;

namespace Consultorio.Models.Dtos
{
    public class ConsultaParams
    {
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public string NomeEspecialidade { get; set; }
    }
}
