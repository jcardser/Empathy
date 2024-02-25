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

        /*Conexión con las otras entidades, Foreing Key
         */

        public ICollection<HealthCondition> HealthConditions { get; set; }

        [Display(Name = "Condiciones")]
        public int HealsthConditionsNumber => HealthConditions == null ? 0 : HealthConditions.Count;

    }
}
