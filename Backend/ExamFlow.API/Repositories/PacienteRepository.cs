using ExamFlow.API.Context;
using ExamFlow.API.Models;
using Microsoft.EntityFrameworkCore;

namespace ExamFlow.API.Repositories
{
    public class PacienteRepository(ExamFlowContext context)
    {
        private readonly ExamFlowContext _context = context;

        public async Task<List<Paciente>> ObterTodosPacientes()
        {
            return await _context.Pacientes
                .AsNoTracking()
                .ToListAsync();
        }
        public async Task<Paciente?> ObterPacientePorId(int id)
        {
            return await _context.Pacientes
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);
        }
        public async Task<Paciente> CriarPaciente(Paciente paciente)
        {
            _context.Pacientes.Add(paciente);

            await _context.SaveChangesAsync();

            return paciente;

        }
    }
}
