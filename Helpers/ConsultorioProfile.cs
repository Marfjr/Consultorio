using AutoMapper;
using Consultorio.Models.Dtos;
using Consultorio.Models.Entities;
using System.Linq;

namespace Consultorio.Helpers
{
    public class ConsultorioProfile : Profile
    {
        public ConsultorioProfile()
        {
            CreateMap<Paciente, PacienteDetalhesDto>();
            CreateMap<Consulta, ConsultaDto>()
                .ForMember(dest => dest.Especialidade, opt => opt.MapFrom(src => src.Especialidade.Nome))
                .ForMember(dest => dest.Profissional, opt => opt.MapFrom(src => src.Profissional.Nome));

            CreateMap<PacienteAdicionarDto, Paciente>();
            CreateMap<PacienteAtualizarDto, Paciente>();



            CreateMap<ConsultaAdicionarDto, Consulta>();
            CreateMap<ConsultaAtualizarDto, Consulta>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Paciente, PacienteDto>();
            CreateMap<Especialidade, EspecialidadeDto>();

            CreateMap<Consulta, ConsultaDetalhesDto>();
            CreateMap<ConsultaAdicionarDto, Consulta>();

   

            CreateMap<Profissional, ProfissionalDetalhesDto>()
                .ForMember(dest => dest.TotalConsultas, opt => opt.MapFrom(src => src.Consultas.Count()))
                .ForMember(dest => dest.Especialidades, opt => opt.MapFrom(src =>
                src.Especialidades.Select(x => x.Nome).ToArray()));
            CreateMap<Profissional, ProfissionalDto>();

            CreateMap<ProfissionalAdicionarDto, Profissional>();
            CreateMap<ProfissionalAtualizarDto, Profissional>();

            CreateMap<Especialidade, EspecialidadeDetalhesDto>();
        }

    }
}
