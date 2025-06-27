using System.ComponentModel.DataAnnotations;

namespace CrudVeiculos.DTOs
{
    public class DocumentoCreateDTO
    {
        [Required(ErrorMessage = "Apelido é obrigatório")]
        public string Apelido { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Arquivo é obrigatório")]
        public IFormFile File { get; set; }


    }
}
