using System.ComponentModel.DataAnnotations;

namespace Empathy.Models
{
    public class DateTimerViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Fecha Disponible [DD/MM/AAAA]")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [MaxLength(10, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres")]
        public string Date { get; set; }

        [Display(Name = "Horas Disponibles [HH:MM]")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [MaxLength(5, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres")]
        public string MediumTime { get; set; }

        public int DoctorId { get; set; }
    }
}
