using ExamFlow.API.Models;
using ExamFlow.API.Repositories;
using ExamFlow.API.Enums;
using ExamFlow.API.DTO.Create;
using ExamFlow.API.DTO.Update;

namespace ExamFlow.API.Services
{
    public class SolicitacaoExameService(SolicitacaoExameRepository repository)
    {
        private readonly SolicitacaoExameRepository _repository = repository;

        public async Task<List<SolicitacaoExame>> ObterTodasSolicitacoes()
        {
            return await _repository.ObterTodasSolicitacoes();
        }
        public async Task<SolicitacaoExame?> ObterSolicitacaoPorId(int id)
        {
            return await _repository.ObterExamesPorId(id);
        }
        public async Task<SolicitacaoExame> CriarSolicitacao(CriarSolicitacaoExameDTO dto)
        {
            var solicitacao = new SolicitacaoExame
            {
                PacienteId = dto.PacienteId,
                UsuarioId = dto.UsuarioId,
                Status = StatusSolicitacao.EmAndamento,
                DataSolicitacao = DateTime.Now,
                Itens = dto.ExameIds.Select(exameId =>
                new ItemSolicitacaoExame
                {
                    ExameId = exameId
                }).ToList()
            };
            return await _repository.CriarSolicitacao(solicitacao);
        }
        public async Task<SolicitacaoExame> AtualizarStatusSolicitacao(int id, AtualizarCadastroDeSolicitacaoDTO dto)
        {
            return await _repository.AtualizarStatusSolicitacao(id, dto.Status);
        }
        public async Task<ItemSolicitacaoExame?> AtualizarResultadoExame(
            int solicitacaoId,
            int exameId,
            AtualizarResultadoExameDTO dto
            )
        {
            return await _repository.AtualizarResultadoExame(
                solicitacaoId,
                exameId,
                dto.Resultado
                );
        }
    }

}
