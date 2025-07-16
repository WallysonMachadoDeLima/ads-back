using System.ComponentModel.DataAnnotations;
using Ads.Enums;

namespace Ads.DTOs
{
    public class CorpoDocenteUpdateDTO
    {
        [Required(ErrorMessage = "Servidor é obrigatório")]
        public int ServidorId { get; set; }

        [Required(ErrorMessage = "Disciplina é obrigatória")]
        public int DisciplinaId { get; set; }

        [Required(ErrorMessage = "Turno é obrigatório")]
        public required string Turno { get; set; }

        [Required(ErrorMessage = "Carga horária semanal é obrigatória")]
        public required string CargaHorariaSemanal { get; set; }

        [Required(ErrorMessage = "Tipo de contrato é obrigatório")]
        public required TipoContrato TipoContrato { get; set; }

        [Required(ErrorMessage = "Observações é obrigatório")]
        public required string Observacoes { get; set; }

        [Required(ErrorMessage = "Situação é obrigatória")]
        public required string Situacao { get; set; }
    }
}
