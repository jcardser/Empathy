using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Empathy.Data.Entities

{
    public class Procedure
    {
        public int Id { get; set; }

        [Display(Name = "Tipo procedimiento")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string TypeProcedure { get; set; }

        [JsonIgnore]
        public History Histories { get; set; }
    }
}
