using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Ads.Enums;

namespace Ads.Entities
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

    public required string Turno { get; set; }

    public required string CargaHorariaSemanal { get; set; }

    public required TipoContrato TipoContrato { get; set; }

    public required string Observacoes { get; set; }

    public required string Situacao { get; set; }
  }
}
