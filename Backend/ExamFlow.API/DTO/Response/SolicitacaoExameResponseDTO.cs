using ExamFlow.API.Enums;

namespace ExamFlow.API.DTO.Response
{

    public class SolicitacaoExameResponseDTO
    {
        public int Id { get; set; }
        
        public int PacienteId { get; set; }
        public string PacienteNome { get; set; }

        public int UsuarioId { get; set; }
        public string UsuarioNome { get; set; }

        public StatusSolicitacao Status { get; set; }
        public DateTime DataSolicitacao { get; set; }
        public List<ExameSolicitadoResponseDTO> Exames { get; set; } = new();
    }

}
