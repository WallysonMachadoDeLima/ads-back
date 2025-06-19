using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CrudVeiculos.Entities
{
    [Table("Aluno")]
    public class Aluno
    {
        [Key]
        public int Id { get; set; }

        public required string Nome { get; set; }

        public required string Cpf { get; set; }

        public required string Email { get; set; }

        public required string Telefone { get; set; }

        public required string Matricula { get; set; }

    }
}