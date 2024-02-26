using Empathy.Data.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Empathy.Models
{
    public class EditAppointmentViewModel
    {
        public string Id { get; set; }

        [Display(Name = "Fecha Cita Medica")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy HH:mm}", NullDisplayText = "")]
        public DateTimeOffset DateTime { get; set; }

        //--ToDo Organizar...

        [Display(Name = "Cuéntanos el motivo de tu consulta.")]
        [MaxLength(300, ErrorMessage = "El campo {0} debe tener máximo {1} carácteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Reason { get; set; }

        //Sede -> Doctor

        [Display(Name = "Sede")]
        [Range(1, int.MaxValue, ErrorMessage = "Debes de seleccionar una Sede / Campus.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int CampusId { get; set; }

        public IEnumerable<SelectListItem> Campus { get; set; }

        [Display(Name = "Médico")]
        [Range(1, int.MaxValue, ErrorMessage = "Debes de seleccionar un Médico / Profesional.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int DoctrId { get; set; }

        public IEnumerable<SelectListItem> Doctors { get; set; }

        [Display(Name = "Condiciones de Salud")]
        public IEnumerable<SelectListItem> HealthConditions { get; set; }


    }
}
