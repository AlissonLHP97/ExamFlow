using ExamFlow.API.Models;
using ExamFlow.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExamFlow.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PacienteController(PacienteService service) : ControllerBase
    {
        private readonly PacienteService _service = service;

        [HttpGet]
        public async Task<ActionResult<List<Paciente>>> ObterPacientes()
        {
            var pacientes = await _service.ObterTodosPacientes();

            return Ok(pacientes);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Paciente>> ObterPacientePorId(int id)
        {
            var paciente = await _service.ObterPacientePorId(id);

            if (paciente is null) return NotFound();

            return Ok(paciente);
        }
        [HttpGet("usuario/{usuarioId}")]
        public async Task<ActionResult<Paciente>> ObterPacientePorUsuarioId(int usuarioId)
        {
            var paciente = await _service.ObterPacientePorUsuarioId(usuarioId);

            if(paciente is null) return NotFound();

            return Ok(paciente);
        }
        [HttpPost]
        public async Task<ActionResult<Paciente>> CriarPaciente(Paciente paciente)
        {
            var pacienteCriado = await _service.CriarPaciente(paciente);

            return CreatedAtAction(
                nameof(ObterPacientePorId),
                new { id = pacienteCriado.Id },
                pacienteCriado
                );
        }
    }
}
