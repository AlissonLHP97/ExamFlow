using ExamFlow.API.DTO.Auth;
using ExamFlow.API.Models;
using ExamFlow.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExamFlow.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController(UsuarioService service) : ControllerBase
    {
        private readonly UsuarioService _service = service;

        [HttpPost("login")]
        public async Task<ActionResult<UsuarioresponseDTO>> Login(LoginDTO dto)
        {
            var usuario = await _service.Login(dto);

            if (usuario is null) return Unauthorized("E-mail ou senha inválidos");

            var response = new UsuarioresponseDTO
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email,
                Perfil = usuario.Perfil
            };

            return Ok(response);

        }

        [HttpGet]
        public async Task<ActionResult<List<Usuario>>> ObterTodosUsuarios()
        {
            var usuarios = await _service.ObterTodosUsuarios();

            return Ok(usuarios);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> ObterUsuarioPorId(int id)
        {
            var usuario = await _service.ObterUsuarioPorId(id);

            if (usuario is null) return NotFound();

            return Ok(usuario);
        }
        [HttpPost]
        public async Task<ActionResult<Usuario>> CriarUsuario(Usuario usuario)
        {
            try
            {
                var usuarioCriado = await _service.CriarUsuario(usuario);

                return CreatedAtAction(
                    nameof(ObterUsuarioPorId),
                    new { id = usuarioCriado.Id },
                    usuarioCriado);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
