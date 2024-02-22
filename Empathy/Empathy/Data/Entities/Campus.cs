using System.ComponentModel.DataAnnotations;

namespace Empathy.Data.Entities
{
    public class Campus
    {
        public int Id { get; set; }

        [Display(Name = "Nombre del campus")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string NameCam { get; set; }

        [Display(Name = "Dirección de sede")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string AddressCam { get; set; }

        [Display(Name = "Telefóno de Sede")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string PhoneCam { get; set; }

        public ICollection<Doctor> Doctors { get; set; }

        [Display(Name = "Médico")]
        public int DoctorsNumber => Doctors == null ? 0 : Doctors.Count;
    }
}
