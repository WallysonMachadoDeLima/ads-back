using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace CrudVeiculos.DTOs
{
    public class DocumentoCreateDTO
    {
        [Required(ErrorMessage = "Nome é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Descrição é obrigatória")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Arquivo é obrigatório")]
        public IFormFile Arquivo { get; set; }
    }
}
