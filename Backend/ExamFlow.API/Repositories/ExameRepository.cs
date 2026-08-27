using ExamFlow.API.Context;
using ExamFlow.API.Models;
using Microsoft.EntityFrameworkCore;

namespace ExamFlow.API.Repositories
{
    public class ExameRepository (ExamFlowContext context)
    {
        private readonly ExamFlowContext _context = context;

        public async Task<List<Exame>> ObterTodosAsync()
        {
            return await _context.Exames
                .AsNoTracking()
                .ToListAsync();
        }
        public async Task<Exame> CriarExame(Exame exame)
        {
            _context.Add(exame);
            await _context.SaveChangesAsync();

            return exame;
        }
    }
}
