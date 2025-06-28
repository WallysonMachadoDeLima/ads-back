using System.ComponentModel.DataAnnotations;

namespace CrudVeiculos.DTOs
{
    public class DocumentoUpdateDTO
    {
        [Required(ErrorMessage = "Nome é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Descrição é obrigatória")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "URL é obrigatória")]
        public string Url { get; set; }
    }
}
