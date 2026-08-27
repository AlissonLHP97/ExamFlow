using ExamFlow.API.Context;
using ExamFlow.API.Models;
using Microsoft.EntityFrameworkCore;

namespace ExamFlow.API.Repositories
{
    public class UsuarioRepository (ExamFlowContext context)
    {
        private readonly ExamFlowContext _context = context;

        public async Task<List<Usuario>> ObterTodosUsuarios()
        {
            return await _context.Usuarios
                .AsNoTracking()
                .ToListAsync();
        }
        public async Task<Usuario?> ObterUsuarioPorId(int id)
        {
            return await _context.Usuarios
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Id == id);
        }
        public async Task<Usuario?> ObterUsuarioPorEmail(string email)
        {
            return await _context.Usuarios
                .FirstOrDefaultAsync(u => u.Email == email);
        }
        public async Task<Usuario> CriarUsuario(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            
            await _context.SaveChangesAsync();
            
            return usuario;
        }
    }
}
