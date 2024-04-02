using AutoMapper;
using Consultorio.Models.Dtos;
using Consultorio.Models.Entities;
using Consultorio.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Consultorio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfissionalController : ControllerBase
    {
        private readonly IProfissionalRepository _repository;
        private readonly IMapper _mapper;

        public ProfissionalController(IProfissionalRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var pacientes = await _repository.GetAllProfissionaisAsync();

            return pacientes.Any()
                ? Ok(pacientes)
                : NotFound("Profissionais não encontrados");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (id <= 0) return BadRequest("Profissional inválido");

            var profissional = await _repository.GetProfissionalByIdAsync(id);

            var profissionalRetorno = _mapper.Map<ProfissionalDetalhesDto>(profissional);

            return profissionalRetorno != null
                ? Ok(profissionalRetorno)
                : NotFound("Profissional não existe na base de dados");
        }

        [HttpPost]
        public async Task<IActionResult> Post(ProfissionalAdicionarDto profissional)
        {
            if (string.IsNullOrEmpty(profissional.Nome)) return BadRequest("Dados inválidos");

            var profissionalAdicionar = _mapper.Map<Profissional>(profissional);

            _repository.Add(profissionalAdicionar);

            return await _repository.SaveChangesAsync()
                ? Ok("Profissional adicionado")
                : BadRequest("Erro ao adicionar o Profissional");

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, ProfissionalAtualizarDto profissional)
        {
            if (id <= 0) return BadRequest("Profissional inválido");

            var profissionalBanco = await _repository.GetProfissionalByIdAsync(id);

            if (profissionalBanco == null)
                return NotFound("Profissional não encontrado na base de dados");

            var profissionalAtualizar = _mapper.Map(profissional, profissionalBanco);

            _repository.Update(profissionalAtualizar);

            return await _repository.SaveChangesAsync()
                ? Ok("Profissional atualizado")
                : BadRequest("Erro ao atualizar o Profissional");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0) return BadRequest("Profissional inválido");

            var profissionalBanco = await _repository.GetProfissionalByIdAsync(id);

            if (profissionalBanco == null)
                return NotFound("Profissional não encontrado na base de dados");

            _repository.Delete(profissionalBanco);

            return await _repository.SaveChangesAsync()
                ? Ok("Profissional deletado")
                : BadRequest("Erro ao deletar o Profissional");
        }

        ///<summary>
        /// Adiciona uma especialidade a um profissional
        ///</summary>

        [HttpPost("adicionar-profissional-a-especialidade")]
        public async Task<IActionResult> PostProfissionalEspecialidade(ProfissionalEspecialidadeAdicionarDto profissional)
        {
            int profissionalId = profissional.ProfissionalId;
            int especialidadeId = profissional.EspecialidadeId;

            if (profissionalId <= 0 || especialidadeId <= 0) return BadRequest("Dados inválidos");

            var profissionalEspecialidade = await _repository.GetProfissionalEspecialidadeAsync(profissionalId, especialidadeId);

            if (profissionalEspecialidade != null) return Ok("Especialidade já cadastrada a esse profissional");

            var especialidadeAdicionar = new ProfissionalEspecialidade
            {
                EspecialidadeId = especialidadeId,
                ProfissionalId = profissionalId
            };

            _repository.Add(especialidadeAdicionar);

            return await _repository.SaveChangesAsync()
                ? Ok("Especialiadade adicionada")
                : BadRequest("Erro ao adicionar especialidade");
        }

        ///<summary>
        /// Deleta uma especialidade de um profissional
        /// </summary>
        [HttpDelete("{profissionalId}/deletar-especialidade-do-profissional/{especialidadeId}")]
        public async Task<IActionResult> DeleteProfissionalEspecialidade(int profissionalId, int especialidadeId)
        {
            if (profissionalId <= 0 || especialidadeId <= 0) return BadRequest("Dados inválidos");

            var profissionalEspecialidade = await _repository.GetProfissionalEspecialidadeAsync(profissionalId, especialidadeId);

            if (profissionalEspecialidade == null)
                return BadRequest("Especialidade não cadastrada");

            _repository.Delete(profissionalEspecialidade);

            return await _repository.SaveChangesAsync()
                ? Ok("Especialiadade deletada do profissional")
                : BadRequest("Erro ao deletar especialidade do profissional");
        }
    }
}
