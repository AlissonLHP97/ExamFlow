namespace ExamFlow.API.DTO.Create
{
    public class CriarSolicitacaoExameDTO
    {
        public int PacienteId { get; set; }
        public int UsuarioId { get; set; }
        public List<int> ExameIds { get; set; }
    }
}
