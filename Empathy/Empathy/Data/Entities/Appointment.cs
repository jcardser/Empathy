using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Empathy.Data.Entities
{
    public class Appointment
    {
        public int Id { get; set; }

        [Display(Name = "Seleccione una fecha disponible")]
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

        [Display(Name ="Indicanos tus Alergias, Medicamentos que consumes, cirugias y/o conmorbilidades")]
        [MaxLength(500, ErrorMessage ="El campo {0} debe tener máximo {1} carácteres")]
        [Required(ErrorMessage ="El campo {0} es obligatorio")]
        public string ConditionHistory { get; set; }

        [Display(Name ="Antecedentes cardiacos familiares")]
        [MaxLength(300, ErrorMessage ="El campo {1} debe tener máximo {1} carácteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public bool CardiacHistory {  get; set; }

        [Display(Name = "Antecedentes presión arterial familiares")]
        [MaxLength(300, ErrorMessage = "El campo {1} debe tener máximo {1} carácteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public bool PressureHistory { get; set; }

        [Display(Name = "Antecedentes azúcar familiares")]
        [MaxLength(300, ErrorMessage = "El campo {1} debe tener máximo {1} carácteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public bool SugarHistory { get; set; }

        [Display(Name = "Indica tu peso (en kilogramos)")]
        [MaxLength(10, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Weight { get; set; }

        [Display(Name = "Indica tu estatura (en centímetros)")]
        [MaxLength(10, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Height { get; set; }

        [Display(Name = "¿Fumas?")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public bool Smoke { get; set; }

        [Display(Name = "¿Consumes bebidas alcoholicas?")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public bool Beer { get; set; }

        [Display(Name = "¿Te has fracturado alguna vez?")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public bool Fracture { get; set; }


        //Estado de la cita lo actualiza el usuario. Funciona Como CRUD

        [Display(Name = "Estado de la cita")]
        public Boolean Status { get; set; }

        //Conexión con Sede//
        public ICollection<Sede> Sedes { get; set; }


    }
}
