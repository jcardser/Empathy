using System.ComponentModel.DataAnnotations;

namespace Empathy.Models
{
    public class ProfessionalViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [MaxLength(30, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres")]
        public string NameProfessional { get; set; }

        public int SedeId { get; set; } 
    }
}
