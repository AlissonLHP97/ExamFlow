namespace ExamFlow.API.Models
{
    public class Exame
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        public ICollection<ItemSolicitacaoExame> Itens { get; set; }
        = new List<ItemSolicitacaoExame>();
    }
}
