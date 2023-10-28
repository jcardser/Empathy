using System.ComponentModel.DataAnnotations;

namespace Empathy.Data.Entities
{
    public class HealthCondition
    {
        public int Id { get; set; }

        [Display(Name = "¿Se ha realizado alguna cirugía?")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Surgery { get; set; }

        [Display(Name = "¿Eres alergíco/a a algún medicamento?")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Allergies { get; set; }

        [Display(Name = "Contacto/s de emergencía")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string EmergencyContact { get; set; }

        [Display(Name = "Indica tu peso (en kilogramos)")]
        [MaxLength(30, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Weight { get; set; }

        [Display(Name = "Indica tu estatura (en centímetros)")]
        [MaxLength(30, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Height { get; set; }

        [Display(Name = "¿Fumas?")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public bool Smoke { get; set; }

        [Display(Name = "¿Consumes bebidas alcoholicas?")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public bool Beer { get; set; }

        [Display(Name = "¿Te has fracturado alguna vez?")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public bool Fracture { get; set; }
    }
}
