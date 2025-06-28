using System.ComponentModel.DataAnnotations;
using CrudVeiculos.Enums;

namespace CrudVeiculos.DTOs
{
    public class ServidorCreateDTO
    {
        [Required(ErrorMessage = "Nome é obrigatório")]
        public required string Nome { get; set; }

        [Required(ErrorMessage = "Cpf é obrigatório")]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "Cpf deve conter 11 dígitos")]
        public required string Cpf { get; set; }

        [Required(ErrorMessage = "Email é obrigatório")]
        [EmailAddress(ErrorMessage = "Email deve ser um endereço de email válido")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "Senha é obrigatória")]
        [MinLength(6, ErrorMessage = "Senha deve ter no mínimo 6 caracteres")]
        public required string Senha { get; set; }

        [Required(ErrorMessage = "Tipo é obrigatório")]
        public required ServidorTipo Tipo { get; set; }
    }
}