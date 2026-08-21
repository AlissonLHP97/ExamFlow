namespace ExamFlow.API.Models
{
    public class Exame
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descrição { get; set; }

        public ICollection<SolicitacaoExame> Solicitacoes { get; set; }
    }
}
