﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Empathy.Data.Entities
{
    public class Appointment
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

        /*Conexión con las otras entidades, Foreing Key
         */
        public ICollection<SedeAppointment> SedesAppointments { get; set; }
        public int SedesNumber => SedesAppointments == null ? 0 : SedesAppointments.Count;
        //[Display(Name = "Sedes")]
        
        //[Display(Name = "Sede / Campus")]
        //public int SedesNumber => Sedes == null ? 0 : Sedes.Count;


    }
}
