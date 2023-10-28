using System.ComponentModel.DataAnnotations;

namespace Empathy.Data.Entities
{
    public class History
    {
        public int Id { get; set; }

        [Display(Name = "Fecha atención")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public DateTime Date { get; set; }

        [Display(Name = "Resumen historia clinica")]
        [MaxLength(500, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Summary { get; set; }
    }
}
