using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Empathy.Data.Entities
{
    public class Doctor
    {
        public int Id { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [MaxLength(30, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres")]
        public string NameDoctor { get; set; }

        [Display(Name = "Especialidad")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [MaxLength(30, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres")]
        public string SpecialtyDoc { get; set; }

        [JsonIgnore]
        public Campus Campus { get; set; }
    }
}
