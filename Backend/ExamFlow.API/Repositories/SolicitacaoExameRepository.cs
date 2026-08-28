using ExamFlow.API.Context;
using ExamFlow.API.DTO.Update;
using ExamFlow.API.Enums;
using ExamFlow.API.Models;
using Microsoft.EntityFrameworkCore;

namespace ExamFlow.API.Repositories
{
    public class SolicitacaoExameRepository(ExamFlowContext context)
    {
        private readonly ExamFlowContext _context = context;
        public async Task<List<SolicitacaoExame>> ObterTodasSolicitacoes()
        {
            return await _context.SolicitacaoExames
                .AsNoTracking()
                .Include(s => s.Paciente)
                .Include(s => s.Usuario)
                .Include(s => s.Itens)
                .ThenInclude(i => i.Exame)
                .ToListAsync();
        }
        public async Task<SolicitacaoExame?> ObterExamesPorId(int id)
        {
            return await _context.SolicitacaoExames
                .AsNoTracking()
                .Include(s => s.Paciente)
                .Include(s => s.Usuario)
                .Include(s => s.Itens)
                .ThenInclude(i => i.Exame)
                .FirstOrDefaultAsync(i => i.Id == id);                
        }
        public async Task<SolicitacaoExame> CriarSolicitacao(SolicitacaoExame solicitacao)
        {
            _context.Add(solicitacao);

            await _context.SaveChangesAsync();

            return solicitacao;
        }
        public async Task<SolicitacaoExame> AtualizarStatusSolicitacao(int id, StatusSolicitacao status)
        {
            var solicitacao = await _context.SolicitacaoExames.FirstOrDefaultAsync(s => s.Id == id);

            if (solicitacao is null) return null;

            solicitacao.Status = status;

            await _context.SaveChangesAsync();

            return solicitacao;
        }
        public async Task<ItemSolicitacaoExame?> AtualizarResultadoExame(
            int solicitacaoId,
            int exameId,
            string resultado
            )
        {
            var item = await _context.ItensSolicitacaoExame
                .FirstOrDefaultAsync(i =>
                i.SolicitacaoExameId == solicitacaoId &&
                i.ExameId == exameId);

            if(item is null ) return null;

            item.Resultado = resultado;
            item.DataResultado = DateTime.Now;

            await _context.SaveChangesAsync();

            return item;
        }
    }
}
