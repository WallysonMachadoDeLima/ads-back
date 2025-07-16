using System.ComponentModel.DataAnnotations;

namespace Ads.DTOs
{
    public class CorpoDocenteCreateDTO
    {
        [Required(ErrorMessage = "Servidor é obrigatório")]
        public int ServidorId { get; set; }

        [Required(ErrorMessage = "Disciplina é obrigatória")]
        public int DisciplinaId { get; set; }
    }
}
