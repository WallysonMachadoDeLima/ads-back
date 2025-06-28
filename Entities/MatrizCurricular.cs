using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace CrudVeiculos.Entities
{
    [Table("MatrizCurricular")]
    public class MatrizCurricular
    {
        [Key]
        public int Id { get; set; }

        public required string Nome { get; set; }

        public required int Ano { get; set; }

        public virtual ICollection<Disciplina> Disciplinas { get; set; }
            = new List<Disciplina>();
    }
}
