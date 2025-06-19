using System;
using System.ComponentModel.DataAnnotations;

namespace CrudVeiculos.DTOs
{
    public class TccUpdateDTO
    {
        [Required(ErrorMessage = "Aluno é obrigatório")]
        public int AlunoId { get; set; }

        [Required(ErrorMessage = "Título provisório é obrigatório")]
        [StringLength(255, ErrorMessage = "Título provisório deve ter no máximo 255 caracteres")]
        public string TituloProvisorio { get; set; }

        [Required(ErrorMessage = "Resumo é obrigatório")]
        public string Resumo { get; set; }

        [Required(ErrorMessage = "Área temática é obrigatória")]
        [StringLength(120, ErrorMessage = "Área temática deve ter no máximo 120 caracteres")]
        public string AreaTematica { get; set; }

        [Required(ErrorMessage = "Orientador é obrigatório")]
        public int OrientadorId { get; set; }

        public int? CoorientadorId { get; set; }

        [Required(ErrorMessage = "Arquivo da proposta é obrigatório")]
        [StringLength(255, ErrorMessage = "Nome do arquivo deve ter no máximo 255 caracteres")]
        public string ArquivoProposta { get; set; }

        [Required(ErrorMessage = "Período é obrigatório")]
        [StringLength(10, ErrorMessage = "Período deve ter no máximo 10 caracteres")]
        public string Periodo { get; set; }

        [Required(ErrorMessage = "Data prevista da defesa é obrigatória")]
        [DataType(DataType.Date)]
        public DateTime DataPrevistaDefesa { get; set; }

        public string? Observacoes { get; set; }
    }
}
