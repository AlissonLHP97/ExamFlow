namespace ExamFlow.API.Models
{
    public class SolicitacaoExame
    {
        public int Id { get; set; }

        public int PacienteId { get; set; }
        public Paciente Paciente { get; set; } 

        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public string Status { get; set; }
        public DateTime DataSolicitacao { get; set; }

        public ICollection<ItemSolicitacaoExame> Itens { get; set; }
    }
}
