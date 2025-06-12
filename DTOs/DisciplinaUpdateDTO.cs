using System.ComponentModel.DataAnnotations;

namespace CrudVeiculos.DTOs
{
    public class DisciplinaUpdateDTO
    {
        [Required(ErrorMessage = "Nome é obrigatório")]
        public required string Nome { get; set; }

        [Required(ErrorMessage = "Código é obrigatório")]
        public required string Codigo { get; set; }

        [Required(ErrorMessage = "Descrição é obrigatória")]
        [MinLength(10, ErrorMessage = "Descrição deve ter no mínimo 10 caracteres")]
        public required string Descricao { get; set; }

        [Required(ErrorMessage = "Objetivos são obrigatórios")]
        [MinLength(10, ErrorMessage = "Objetivos deve ter no mínimo 10 caracteres")]
        public required string Objetivos { get; set; }

        [Required(ErrorMessage = "Conteúdo é obrigatório")]
        [MinLength(10, ErrorMessage = "Conteúdo deve ter no mínimo 10 caracteres")]
        public required string Conteudo { get; set; }
    }
}