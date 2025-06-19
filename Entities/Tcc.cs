using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrudVeiculos.Entities
{
  public enum TccStatus
  {
    Rascunho,
    Submetido,
    Aprovado,
    Reprovado
  }

  [Table("Tcc")]
  public class Tcc
  {
    [Key]
    public int Id { get; set; }


    [Required]
    public int AlunoId { get; set; }
    [ForeignKey(nameof(AlunoId))]
    public virtual Aluno Aluno { get; set; }

    [Required, StringLength(255)]
    public string TituloProvisorio { get; set; }

    [Required]
    public string Resumo { get; set; }

    [Required, StringLength(120)]
    public string AreaTematica { get; set; }

    [Required]
    public int OrientadorId { get; set; }
    [ForeignKey(nameof(OrientadorId))]
    public virtual Servidor Orientador { get; set; }

    public int? CoorientadorId { get; set; }
    [ForeignKey(nameof(CoorientadorId))]
    public virtual Servidor? Coorientador { get; set; }

    [Required, StringLength(255)]
    public string ArquivoProposta { get; set; }

    [Required, StringLength(10)]
    public string Periodo { get; set; }

    [Required, DataType(DataType.Date)]
    public DateTime DataPrevistaDefesa { get; set; }

    [Required]
    public TccStatus Status { get; set; } = TccStatus.Rascunho;

    [Required, DataType(DataType.Date)]
    public DateTime DataSubmissao { get; set; }

    [DataType(DataType.Date)]
    public DateTime? DataAprovacao { get; set; }

    public string? Observacoes { get; set; }
  }
}
