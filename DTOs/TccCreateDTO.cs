using System;
using System.ComponentModel.DataAnnotations;
using CrudVeiculos.Enums;

namespace CrudVeiculos.DTOs
{
    public class TccCreateDTO
    {
        [Required(ErrorMessage = "Aluno é obrigatório")]
        public int AlunoId { get; set; }

        [Required(ErrorMessage = "Título provisório é obrigatório")]
        [StringLength(255, ErrorMessage = "Título provisório deve ter no máximo 255 caracteres")]
        public string TituloProvisorio { get; set; } = null!;

        [Required(ErrorMessage = "Resumo é obrigatório")]
        public string Resumo { get; set; } = null!;

        [Required(ErrorMessage = "Área temática é obrigatória")]
        [StringLength(120, ErrorMessage = "Área temática deve ter no máximo 120 caracteres")]
        public string AreaTematica { get; set; } = null!;

        [Required(ErrorMessage = "Orientador é obrigatório")]
        public int OrientadorId { get; set; }

        public int? CoorientadorId { get; set; }

        [Required(ErrorMessage = "Arquivo da proposta é obrigatório")]
        [StringLength(255, ErrorMessage = "Nome do arquivo deve ter no máximo 255 caracteres")]
        public string ArquivoProposta { get; set; } = null!;

        [Required(ErrorMessage = "Período é obrigatório")]
        [StringLength(10, ErrorMessage = "Período deve ter no máximo 10 caracteres")]
        public string Periodo { get; set; } = null!;

        [Required(ErrorMessage = "Data prevista da defesa é obrigatória")]
        [DataType(DataType.Date)]
        public DateTime DataPrevistaDefesa { get; set; }

        [Required(ErrorMessage = "Status é obrigatória")]
        public TccStatus Status { get; set; }

        public string? Observacoes { get; set; }
    }
}
