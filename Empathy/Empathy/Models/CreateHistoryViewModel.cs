using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Empathy.Models
{
    public class CreateHistoryViewModel : EditHistoryViewModel
    {
        [Display(Name = "Procedimiento")]
        [Range(1, int.MaxValue, ErrorMessage = "Debes seleccionar un procedimiento.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int ProcedureId { get; set; }

        public IEnumerable<SelectListItem> Procedures { get; set; }

    }
}
