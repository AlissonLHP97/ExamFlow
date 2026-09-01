using ExamFlow.API.Enums;

namespace ExamFlow.API.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public PerfilUsuario Perfil { get; set; }

        public Paciente? Paciente { get; set; }

        public ICollection<SolicitacaoExame>  Solicitacoes { get; set; }
        = new List<SolicitacaoExame>();
    }
}
