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
    }
}
