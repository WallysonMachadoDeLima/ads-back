using System.ComponentModel.DataAnnotations;

namespace CrudVeiculos.DTOs
{
    public class AlunoUpdateDTO
    {
        [Required(ErrorMessage = "Nome é obrigatório")]
        public required string Nome { get; set; }

        [Required(ErrorMessage = "CPF é obrigatório")]
        public required string Cpf { get; set; }

        [Required(ErrorMessage = "Email é obrigatório")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "Telefone é obrigatório")]
        public required string Telefone { get; set; }

        [Required(ErrorMessage = "Matrícula é obrigatória")]
        public required string Matricula { get; set; }
    }
}
