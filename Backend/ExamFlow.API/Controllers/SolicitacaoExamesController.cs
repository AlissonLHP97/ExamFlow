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
                UsuarioId = s.UsuarioId,
                Status = s.Status,
                DataSolicitacao = s.DataSolicitacao,
                ExameIds = s.Itens
            .Select(i => i.ExameId)
            .ToList()
            }).ToList();

            return Ok(response);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<SolicitacaoExame>> ObterSolicitacaoPorId(int id)
        {
            var solicitacao = await _service.ObterSolicitacaoPorId(id);

            if (solicitacao is null) return NotFound();

            return Ok(solicitacao);
        }
        [HttpPost]
        public async Task<ActionResult<SolicitacaoExameResponseDTO>> CriarSolicitacao(CriarSolicitacaoExameDTO dto)
        {
            var solicitacao = await _service.CriarSolicitacao(dto);

            var response = new SolicitacaoExameResponseDTO
            {
                Id = solicitacao.Id,
                PacienteId = solicitacao.PacienteId,
                UsuarioId = solicitacao.UsuarioId,
                Status = solicitacao.Status,
                DataSolicitacao = solicitacao.DataSolicitacao,
                ExameIds = solicitacao.Itens
            .Select(i => i.ExameId)
            .ToList()
            };

            return CreatedAtAction(
                nameof(ObterSolicitacaoPorId),
                new { id = solicitacao.Id },
                response
                );
        }
        [HttpPut("{id}/status")]
        public async Task<ActionResult<SolicitacaoExame>> AtualizarStatusSolicitacao(int id, AtualizarCadastroDeSolicitacaoDTO dto)
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
