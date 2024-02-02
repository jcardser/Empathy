using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Empathy.Data.Entities
{
    public class Sede
    {
        public int Id { get; set; }

        [Display(Name = "Nombre del campus")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string NameCampus { get; set; }

        [Display(Name = "Dirección del campus")]
        [MaxLength(80, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string AddressCampus { get; set; }

        [Display(Name = "Telefóno del campus")]
        [MaxLength(10, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string PhoneCampus { get; set; }

        public ICollection<SedeAppointment> SedeAppointments { get; set; }
        //[Display(Name = "# Cita")]
        public int SedeNumber => SedeAppointments == null ? 0 : SedeAppointments.Count();


    }
}
