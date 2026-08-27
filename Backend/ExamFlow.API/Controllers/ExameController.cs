using ExamFlow.API.Models;
using ExamFlow.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExamFlow.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExameController(ExameService service) : ControllerBase
    {
        private readonly ExameService _service = service;

        [HttpGet]
        public async Task<ActionResult<List<Exame>>> ObterTodosExames()
        {
            var exames = await _service.ObterTodosAsync();
            
            return Ok(exames);
        }
        [HttpPost]
        public async Task<ActionResult<Exame>> CriarExame(Exame exame)
        {
            var exameCriado = await _service.CriarExame(exame);

            if (exameCriado is null) return NotFound();

            return Ok(exameCriado);
        }
    }
}
