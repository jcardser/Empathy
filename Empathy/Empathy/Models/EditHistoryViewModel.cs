using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Empathy.Models
{
    public class EditHistoryViewModel
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

        [Display(Name = "Sintomas y duración")]
        [MaxLength(500, ErrorMessage = "El campo {0} debe tener máximo {1} carácteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Symptoms { get; set; }

        [Display(Name = "Hallazgos medicos")]
        [MaxLength(500, ErrorMessage = "El campo {0} debe tener máximo {1} carácteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Notes { get; set; }

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

        [Display(Name = "Resultado examenes fisicos")]
        [MaxLength(500, ErrorMessage = "El campo {0} debe contener máximo {1} carácteres.")]
        public string PhysicalExam { get; set; }

        [Display(Name = "Diagnostico")]
        [MaxLength(500, ErrorMessage = "El campo {0} debe contener máximo {1} carácteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Diagnosis { get; set; }
    }
}
