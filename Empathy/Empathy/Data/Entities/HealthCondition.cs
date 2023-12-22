using System.ComponentModel.DataAnnotations;

namespace Empathy.Data.Entities
{
    public class HealthCondition
    {
        public int Id { get; set; }

       
        [Display(Name = "¿Eres casad@?")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public bool CivilStatus { get; set; }

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

       

        //Conexión a Cita Médica
        public Appointment Appointment { get; set; }
    }
}
