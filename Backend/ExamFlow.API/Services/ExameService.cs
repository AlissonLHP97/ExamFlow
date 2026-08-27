using ExamFlow.API.Models;
using ExamFlow.API.Repositories;

namespace ExamFlow.API.Services
{
    public class ExameService(ExameRepository repository)
    {
        private readonly ExameRepository _repository = repository;

        public async Task<List<Exame>> ObterTodosAsync()
        {
            return await _repository.ObterTodosAsync();
        }
        public async Task<Exame> CriarExame(Exame exame)
        {
            return await _repository.CriarExame(exame);
        }
    }
}
