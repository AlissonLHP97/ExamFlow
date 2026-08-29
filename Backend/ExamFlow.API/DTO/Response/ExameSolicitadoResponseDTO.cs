namespace ExamFlow.API.DTO.Response
{
    public class ExameSolicitadoResponseDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string? Resultado { get; set; }
        public DateTime? DataResultado { get; set; }
    }
}
