using ExamFlow.API.Enums;

namespace ExamFlow.API.DTO.Auth
{
    public class UsuarioresponseDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public PerfilUsuario Perfil { get; set; }
    }
}
