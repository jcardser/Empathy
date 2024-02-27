using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Empathy.Data.Entities
{
    public class DateTimer
    {
        public int Id { get; set; }

        [Display(Name = "Fecha Disponible [DD/MM/AAAA]")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [MaxLength(10, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres")]
        public string Date { get; set; }

        [Display(Name = "Horas Disponibles [HH:MM]")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [MaxLength(5, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres")]
        public string MediumTime { get; set; }

        [JsonIgnore]
        public Doctor Doctor{ get; set; }

    }
}
