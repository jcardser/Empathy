using Empathy.Data.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Empathy.Models
{
    public class AddAppointmentViewModel : EditAppointmentViewModel
    {
        [Display(Name ="Sede")]
        [Range(1, int.MaxValue, ErrorMessage ="Deses seleccionar una sede")]
        [Required(ErrorMessage ="El campo{0} es obligatorio")]
        public int SedeId { get; set; }

        public IEnumerable<SelectListItem> Sedes { get; set; }
    }
}
