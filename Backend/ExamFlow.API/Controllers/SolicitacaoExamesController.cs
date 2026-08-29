using ExamFlow.API.DTO.Create;
using ExamFlow.API.DTO.Response;
using ExamFlow.API.DTO.Update;
using ExamFlow.API.Models;
using ExamFlow.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExamFlow.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SolicitacaoExamesController(SolicitacaoExameService service) : ControllerBase
    {
        private readonly SolicitacaoExameService _service = service;

        [HttpGet]
        public async Task<ActionResult<SolicitacaoExameResponseDTO>> ObterTodasSolicitacoesExames()
        {
            var solicitacoes = await _service.ObterTodasSolicitacoes();

            var response = solicitacoes.Select(s => new SolicitacaoExameResponseDTO
            {
                Id = s.Id,
                PacienteId = s.PacienteId,

                PacienteNome = s.Paciente.Nome,
                UsuarioId = s.UsuarioId,
                UsuarioNome = s.Usuario.Nome,

                Status = s.Status,
                DataSolicitacao = s.DataSolicitacao,
                Exames = s.Itens.Select(i => 
                new ExameSolicitadoResponseDTO
                {
                    Id = i.ExameId,
                    Nome = i.Exame.Nome,
                    Resultado = i.Resultado,
                    DataResultado = i.DataResultado
                }).ToList()

            }).ToList();

            return Ok(response);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<SolicitacaoExameResponseDTO>> ObterSolicitacaoPorId(int id)
        {
            var solicitacao = await _service.ObterSolicitacaoPorId(id);

            if (solicitacao is null) return NotFound();

            var response = new SolicitacaoExameResponseDTO
            {
                Id = solicitacao.Id,

                PacienteId = solicitacao.PacienteId,
                PacienteNome = solicitacao.Paciente.Nome,

                UsuarioId = solicitacao.UsuarioId,
                UsuarioNome = solicitacao.Usuario.Nome,

                Status = solicitacao.Status,
                DataSolicitacao = solicitacao.DataSolicitacao,

                Exames = solicitacao.Itens.Select(i =>
                new ExameSolicitadoResponseDTO
                {
                    Id = i.Exame.Id,
                    Nome = i.Exame.Nome,
                    Resultado = i.Resultado,
                    DataResultado = i.DataResultado
                }).ToList()

            };

            return Ok(response);
        }
        [HttpPost]
        public async Task<ActionResult<SolicitacaoExameResponseDTO>> CriarSolicitacao(CriarSolicitacaoExameDTO dto)
        {
            var solicitacaoCriada = await _service.CriarSolicitacao(dto);

            var solicitacao = await _service.ObterSolicitacaoPorId(solicitacaoCriada.Id);

            if (solicitacao is null) return NotFound();
            
            var response = new SolicitacaoExameResponseDTO
            {
                Id = solicitacao.Id,

                PacienteId = solicitacao.PacienteId,
                PacienteNome = solicitacao.Paciente.Nome,

                UsuarioId = solicitacao.UsuarioId,
                UsuarioNome = solicitacao.Usuario.Nome,

                Status = solicitacao.Status,
                DataSolicitacao = solicitacao.DataSolicitacao,

                Exames = solicitacao.Itens.Select(i => 
                new ExameSolicitadoResponseDTO
                {
                    Id = i.Exame.Id,
                    Nome = i.Exame.Nome,
                    Resultado = i.Resultado,
                    DataResultado = i.DataResultado
                }).ToList()
            };

            return CreatedAtAction(
                nameof(ObterSolicitacaoPorId),
                new { id = solicitacao.Id },
                response
                );
        }
        [HttpPut("{id}/status")]
        public async Task<ActionResult<SolicitacaoExame>> AtualizarStatusSolicitacao(int id, AtualizarStatusDeSolicitacaoDTO dto)
        {
            var solicitacao = await _service.AtualizarStatusSolicitacao(id, dto);

            if (solicitacao is null) return NotFound();

            return NoContent();
        }
        [HttpPut("{solicitacaoId}/exames/{exameId}/resultado")]
        public async Task<ActionResult> AtualizarResultadoExame(
            int solicitacaoId,
            int exameId,
            AtualizarResultadoExameDTO dto)
        {
            var item = await _service.AtualizarResultadoExame(
            solicitacaoId,
            exameId,
            dto);

            if (item is null) return NotFound("Exame não encontrado nesta solicitação.");

            return NoContent();
        }
    }
}
