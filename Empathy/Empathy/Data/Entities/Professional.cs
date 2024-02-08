using System.ComponentModel.DataAnnotations;

namespace Empathy.Data.Entities
{
    public class Professional
    {
        public int Id { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [MaxLength(30, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres")]
        public string NameProfessional { get; set; }

        [Display(Name = "Especialidad")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [MaxLength(30, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres")]
        public string Specialty { get; set; }

        public ICollection<Sede> Sedes { get; set; }
        //public ICollection<SedeProfessional> SedeProfessionals { get; set; }
        //public int SedeNumbers => SedeProfessionals == null ? 0 : SedeProfessionals.Count();

    }
}
