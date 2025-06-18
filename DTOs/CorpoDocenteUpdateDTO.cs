using System.ComponentModel.DataAnnotations;

namespace CrudVeiculos.DTOs
{
    public class CorpoDocenteUpdateDTO
    {
        [Required(ErrorMessage = "Servidor é obrigatório")]
        public int ServidorId { get; set; }

        [Required(ErrorMessage = "Disciplina é obrigatória")]
        public int DisciplinaId { get; set; }
    }
}
