using Empathy.Data.Entities;
using Empathy.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Empathy.Models
{
    public class AddAppointmentViewModel : EditAppointmentViewModel
    {

        

        [Display(Name = "Campus")]
        [Range(1, int.MaxValue, ErrorMessage = "Debes seleccionar una Sede.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int CampusId { get; set; }

        [Display(Name = "Doctor")]
        [Range(1, int.MaxValue, ErrorMessage = "Debes seleccionar un doctor.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int DoctorId { get; set; }

        [Display(Name = "Disponibilidad")]
        [Range(1, int.MaxValue, ErrorMessage = "Debes seleccionar una Fecha / Hora.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int DateTimerId { get; set; }
        public IEnumerable<SelectListItem> Campuses { get; set; }
        public IEnumerable<SelectListItem> Doctors { get; set; }
        public IEnumerable<SelectListItem> DateTimers { get; set; }

    }
}
