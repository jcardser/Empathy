using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Empathy.Data.Entities
{
    public class Appointment
    {
        public int Id { get; set; }

        [Display(Name = "Fecha cita medica")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime Date { get; set; }

        [Display(Name = "Estado de la cita")]
        public Boolean Status { get; set; }

        [Display(Name = "Motivo de la cita médica")]
        [MaxLength(200, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Reason { get; set; }

        //Conexión con Sede//
        public ICollection<Appointment> Appointments { get; set; }

        public ICollection<HealthCondition> HealthConditions { get; set; }  

    }
}
