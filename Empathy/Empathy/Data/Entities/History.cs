 using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Empathy.Data.Entities
{
    public class History
    {
        public int Id { get; set; }

        [Column(TypeName = "datetime")]
        [Display(Name = "Fecha atención")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public DateTime Date { get; set; }

        [Display(Name = "Motivo de la consulta")]
        [MaxLength(500, ErrorMessage = "El campo {0} debe tener máximo {1} carácteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Summary { get; set; }
        
        //Pendiente de incluir a la vista

        [Display(Name = "Sintomas y duración")]
        [MaxLength(500, ErrorMessage = "El campo {0} debe tener máximo {1} carácteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Symptoms { get; set; }

        //Pendiente de incluir a la vista

        [Display(Name ="Hallazgos medicos")]
        [MaxLength(500, ErrorMessage ="El campo {0} debe tener máximo {1} carácteres")]
        [Required(ErrorMessage ="El campo {0} es obligatorio")]
        public string Notes { get; set; }

        

        /* Objetos examen físico:
         * 1. Presión arterial.
         * 2. Frecuencia cardiaca.
         * 3. Frecuencia respiratoria.
         * 4. Temperatura.
         */
        [Display(Name = "Presión arterial")]
        [MaxLength(500, ErrorMessage = "El campo {0} debe contener máximo {1} carácteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string BloodPressure { get; set; }


        [Display(Name = "Frecuencia cardiaca")]
        [MaxLength(500, ErrorMessage = "El campo {0} debe contener máximo {1} carácteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string HeartRate { get; set; }

        [Display(Name = "Frecuencia respiratoria")]
        [MaxLength(500, ErrorMessage = "El campo {0} debe contener máximo {1} carácteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string BreathingFrequency { get; set; }

        [Display(Name = "Frecuencia respiratoria")]
        [MaxLength(500, ErrorMessage = "El campo {0} debe contener máximo {1} carácteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Temperature { get; set; }


        //Pendiente de incluir a la vista

        [Display(Name = "Resultado examenes fisicos")]
        [MaxLength(500, ErrorMessage = "El campo {0} debe contener máximo {1} carácteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string PhysicalExam { get; set; }

        //Pendiente de incluir a la vista

        [Display(Name ="Diagnostico")]
        [MaxLength(500, ErrorMessage ="El campo {0} debe contener máximo {1} carácteres.")]
        [Required(ErrorMessage ="El campo {0} es obligatorio.")]
        public string Diagnosis { get; set; }

        
        
        //Debe organizarse el motivo de la consulta//
        //Conexión con procedimientos//
        //public ICollection<Procedure> Procedures { get; set; }
    }
}
