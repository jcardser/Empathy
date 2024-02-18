using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Empathy.Models
{
    public class EditAppointmentViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Fecha Cita Medica")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime Date { get; set; }

        //--ToDo Organizar...

        [Display(Name = "Cuéntanos el motivo de tu consulta.")]
        [MaxLength(300, ErrorMessage = "El campo {0} debe tener máximo {1} carácteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Reason { get; set; }

        // Agrega esta propiedad para mostrar las opciones de profesionales en la vista
        public IEnumerable<SelectListItem> ProfessionalOptions { get; set; }
    }
}