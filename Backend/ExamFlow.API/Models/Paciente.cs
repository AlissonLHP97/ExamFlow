namespace ExamFlow.API.Models
{
    public class Paciente
    {
        public int Id { get; set; }

        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public string Nome { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Genero { get; set; }
        public string Telefone { get; set; }

        public ICollection<SolicitacaoExame> Solicitacoes { get; set; } 
            = new List<SolicitacaoExame>();
    }
}
