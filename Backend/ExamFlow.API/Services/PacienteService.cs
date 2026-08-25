using ExamFlow.API.Models;
using ExamFlow.API.Repositories;

namespace ExamFlow.API.Services
{
    public class PacienteService(PacienteRepository repository)
    {
        private readonly PacienteRepository _repository = repository;

        public async Task<List<Paciente>> ObterTodosPacientes()
        {
            return await _repository.ObterTodosPacientes();
        }
        public async Task<Paciente?> ObterPacientePorId(int id)
        {
            return await _repository.ObterPacientePorId(id);
        }
        public async Task<Paciente> CriarPaciente(Paciente paciente)
        {
            return await _repository.CriarPaciente(paciente);
        }
    }
}
