using System.ComponentModel.DataAnnotations;

namespace Empathy.Models
{
    public class EditProfessionalViewModel
    {
        [Display(Name = "Nombre")]
        [MaxLength(30, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string NameProfessional { get; set; }

        [Display(Name = "Especialidad")]
        [MaxLength(30, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Specialty { get; set; }


    }
}
