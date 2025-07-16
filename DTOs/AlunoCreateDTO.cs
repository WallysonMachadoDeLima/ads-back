using System.ComponentModel.DataAnnotations;

namespace Ads.DTOs
{
    public class AlunoCreateDTO
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

        [Required(ErrorMessage = "Data de Nascimento é obrigatória")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "Sexo é obrigatório")]
        public required string Sexo { get; set; }

        [Required(ErrorMessage = "Período é obrigatório")]
        public required string Periodo { get; set; }

        [Required(ErrorMessage = "Situação é obrigatória")]
        public required string Situacao { get; set; }
    }
}
