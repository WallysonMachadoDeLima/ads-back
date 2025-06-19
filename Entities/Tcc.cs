using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

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

    public int AlunoId { get; set; }
    [ForeignKey(nameof(AlunoId))]
    [JsonIgnore]
    public virtual Aluno Aluno { get; set; }

    [StringLength(255)]
    public required string TituloProvisorio { get; set; }

    public required string Resumo { get; set; }

    [StringLength(120)]
    public required string AreaTematica { get; set; }

    public int OrientadorId { get; set; }
    [ForeignKey(nameof(OrientadorId))]
    [JsonIgnore]
    public virtual Servidor Orientador { get; set; }

    public int? CoorientadorId { get; set; }
    [ForeignKey(nameof(CoorientadorId))]
    [JsonIgnore]
    public virtual Servidor? Coorientador { get; set; }

    [StringLength(255)]
    public required string ArquivoProposta { get; set; }

    [StringLength(10)]
    public required string Periodo { get; set; }

    [DataType(DataType.Date)]
    public required DateTime DataPrevistaDefesa { get; set; }

    public TccStatus Status { get; set; } = TccStatus.Rascunho;

    [DataType(DataType.Date)]
    public required DateTime DataSubmissao { get; set; }

    [DataType(DataType.Date)]
    public DateTime? DataAprovacao { get; set; }

    public string? Observacoes { get; set; }
  }
}
