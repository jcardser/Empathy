using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Empathy.Models
{
    public class CreateProfessionalViewModel : EditProfessionalViewModel
    {
        [Display(Name = "Sede")]
        [Range(1, int.MaxValue, ErrorMessage = "Debes seleccionar una Sede.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int SedeId { get; set; }

        public IEnumerable<SelectListItem> Sedes { get; set; }
    }
}
