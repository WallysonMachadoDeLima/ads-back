using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrudVeiculos.Entities
{
  [Table("Documento")]
  public class Documento
  {
    [Key]
    public int Id { get; set; }

    public required string Nome { get; set; }

    public required string Descricao { get; set; }

    public required string Url { get; set; }
  }
}
