using System.ComponentModel.DataAnnotations;

namespace Empathy.Data.Entities

{
    public class Procedure
    {
        public int Id { get; set; }

        [Display(Name = "Tipo procedimiento")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string TypeProcedure { get; set; }

        public ICollection<History> Histories { get; set; }
    }
}
