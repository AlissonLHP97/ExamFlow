using System.ComponentModel.DataAnnotations;

namespace ExamFlow.API.DTO.Update
{
    public class AtualizarResultadoExameDTO
    {
        [Required]
        public string Resultado { get; set; }
    }
}
