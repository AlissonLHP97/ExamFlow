using ExamFlow.API.DTO.Auth;
using ExamFlow.API.Models;
using ExamFlow.API.Repositories;

namespace ExamFlow.API.Services
{
    public class UsuarioService(UsuarioRepository repository)
    {
        private readonly UsuarioRepository _repository = repository;

        public async Task<Usuario?> Login(LoginDTO dto)
        {
            var usuario = await _repository.ObterUsuarioPorEmail(dto.Email);

            if (usuario is null) return null;

            if (usuario.Senha != dto.Senha) return null;

            return usuario;
        }

        public async Task<List<Usuario>> ObterTodosUsuarios()
        {
            return await _repository.ObterTodosUsuarios();
        }
        public async Task<Usuario?> ObterUsuarioPorId(int id)
        {
            return await _repository.ObterUsuarioPorId(id);
        }
        public async Task<Usuario?> ObterUsuarioPorEmail(string email)
        {
            return await _repository.ObterUsuarioPorEmail(email);
        }
        public async Task<Usuario> CriarUsuario(Usuario usuario)
        {
            var usuarioExistente = await _repository.ObterUsuarioPorEmail(usuario.Email);

            if (usuarioExistente is not null)
                throw new InvalidOperationException("Já existe um usuário com esse e-mail.");

            return await _repository.CriarUsuario(usuario);
        }
    }
}
