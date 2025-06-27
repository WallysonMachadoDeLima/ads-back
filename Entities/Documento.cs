using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CrudVeiculos.Entities
{
    [Table("Documento")]
    public class Documento
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FileName { get; set; }
        [Required]
        public string Nome { get; set; }

        [Required]
        public string Apelido { get; set; }

        [Required]
        public string Url { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
