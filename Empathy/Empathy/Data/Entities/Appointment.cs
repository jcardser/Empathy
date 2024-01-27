using System.ComponentModel.DataAnnotations;
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

        /* ::ESPACIO INFORMATIVO::
         * En este espacio, se solicita el historial medico previo, tales como:
         * 1. Alergias.
         * 2. Medicamentos.
         * 3. Cirugias.
         * 4. Conmobilidades.
         */

        //Pendiente asociar sede
        //pendiete asociar profesional de salud


        //Estado de la cita lo actualiza el usuario. Funciona Como CRUD

        //[Display(Name = "Estado de la cita")]
        //public Boolean Status { get; set; }

        //Conexión con Sede//
        //public ICollection<Sede> Sedes { get; set; }


        //Conexión con Tipo Categoría
        
        //public ICollection<Category> Categories { get; set; }   


    }
}
