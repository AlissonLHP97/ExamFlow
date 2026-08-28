namespace ExamFlow.API.Models
{
    public class ItemSolicitacaoExame
    {
        public int Id { get; set; }

        public int SolicitacaoExameId { get; set; }
        public SolicitacaoExame SolicitacaoExame { get; set; }

        public string? Resultado { get; set; }
        public DateTime? DataResultado { get; set; }

        public int ExameId { get; set; }
        public Exame Exame { get; set; }
    }
}