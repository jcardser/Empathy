using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Empathy.Data.Entities
{
    public class Appointment
    {
        public int Id { get; set; }

        [Display(Name = "Fecha Cita Medica")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy HH:mm}", NullDisplayText = "")]
        public DateTimeOffset DateTime { get; set; }

        //--ToDo Organizar...

        [Display(Name = "Cuéntanos el motivo de tu consulta.")]
        [MaxLength(300, ErrorMessage = "El campo {0} debe tener máximo {1} carácteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Reason { get; set; }

        /*
         * Conexión con las otras entidades, Foreing Key
         */
        public ICollection<AppointmentCampus> AppointmentCampuses { get; set; }

        [Display(Name = "Sede")]
        public int AppointmentsCampusesNumbers => AppointmentCampuses == null ? 0 : AppointmentCampuses.Count;

        public ICollection<AppointmentDoctor> AppointmentDoctors { get; set; }
        [Display(Name ="Doctor")]
        public int AppointmentDoctorsNumbers => AppointmentDoctors == null ? 0 : AppointmentDoctors.Count;

        public ICollection<AppointmentDateTimer> AppointmentDateTimers { get; set; }
        public int AppointmentsDateTimerNumbers => AppointmentDateTimers == null ? 0 : AppointmentDateTimers.Count;

        public ICollection<HealthCondition> HealthConditions { get; set; }

        [Display(Name = "Condiciones")]
        public int HealsthConditionsNumber => HealthConditions == null ? 0 : HealthConditions.Count;

        /*
         * Conexión con SEDE
         */

        //[Display(Name = "Doctor")]
        //public Doctor Doctor { get; set; }

    }
}
