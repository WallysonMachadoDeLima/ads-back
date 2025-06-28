using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using CrudVeiculos.Enums;

namespace CrudVeiculos.Entities
{
    [Table("Servidor")]
    public class Servidor
    {
        [Key]
        public int Id { get; set; }

        public required string Nome { get; set; }

        public required string Cpf { get; set; }

        public required string Email { get; set; }

        public required string Senha { get; set; }

        public required ServidorTipo Tipo { get; set; }

    }
}