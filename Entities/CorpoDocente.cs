using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrudVeiculos.Entities
{
  [Table("CorpoDocente")]
  public class CorpoDocente
  {
    [Key]
    public int Id { get; set; }

    public int DisciplinaId { get; set; }

    [ForeignKey(nameof(DisciplinaId))]
    public virtual Disciplina Disciplina { get; set; }

    public int ServidorId { get; set; }

    [ForeignKey(nameof(ServidorId))]
    public virtual Servidor Servidor { get; set; }
  }
}
