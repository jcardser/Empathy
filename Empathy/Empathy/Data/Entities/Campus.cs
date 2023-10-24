using System.ComponentModel.DataAnnotations;

namespace Empathy.Data.Entities
{
    public class Campus
    {
        public int Id { get; set; }

        [Display(Name = "Combre del campus")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string NameCampus { get; set; }

        [Display(Name = "Combre del campus")]
        [MaxLength(80, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string AddressCampus { get; set; }

        [Display(Name = "Combre del campus")]
        [MaxLength(10, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public int PhoneCampus { get; set; }
    }
}
