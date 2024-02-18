using Empathy.Data.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Empathy.Models
{
    public class AddAppointmentViewModel : EditAppointmentViewModel
    {
        [Display(Name = "Profesional")]
        [Required(ErrorMessage = "Debes seleccionar un profesional")]
        public int SelectedProfessionalId { get; set; }

        // Este es el ID de la sede seleccionada, pero no se está asignando ningún valor a esta propiedad en la acción Create
        public int SelectedSedeId { get; set; }

        // Opciones para profesionales y sede
        public IEnumerable<SelectListItem> ProfessionalOptions { get; set; }
        public IEnumerable<SelectListItem> SedeOptions { get; set; }

    }
}
