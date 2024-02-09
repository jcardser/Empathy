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

        [Display(Name = "Dirección de sede")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Address { get; set; }

        [Display(Name = "Telefóno de Sede")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string PhtoneCampus { get; set; }

        //Conexión con Cita médica
        public ICollection<SedeAppointment> SedeAppointments { get; set; }
        [Display(Name = "# Sedes")]
        public int SedeNumber => SedeAppointments == null ? 0 : SedeAppointments.Count();

        //Conexión con Cita médica
        //public ICollection<SedeProfessional> SedeProfessionals{ get; set; }
        //[Display(Name = "# Profesionales")]
        //public int SedeNumbers => SedeProfessionals == null ? 0 : SedeProfessionals.Count();


    }
}
