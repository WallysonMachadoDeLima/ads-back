
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace CrudVeiculos.Entities
{
    [Table("Disciplina")]
    public class Disciplina
    {
        [Key]
        public int Id { get; set; }

        public required string Nome { get; set; }

        public required string Codigo { get; set; }

        public required string Descricao { get; set; }

        public required string Objetivos { get; set; }

        public required string Conteudo { get; set; }
    }
}