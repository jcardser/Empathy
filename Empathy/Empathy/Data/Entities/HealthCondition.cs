using System.ComponentModel.DataAnnotations;

namespace Empathy.Data.Entities
{
    public class HealthCondition
    {
        public int Id { get; set; }

        /* Alergias y/o medicamentos
         */
        [Display(Name = "¿Eres alergico a algún medicamento?")]
        [MaxLength(500, ErrorMessage = "El campo {0} debe tener máximo {1} carácteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string ConditionHistory { get; set; }

        [Display(Name = "¿Tomas algún medicamento actualmente?")]
        [MaxLength(500, ErrorMessage = "El campo {0} debe tener máximo {1} carácteres")]
        public string Medicine { get; set; }


        /* Procesos medicos
         */

        [Display(Name = "¿Te haz realizado alguna cirugia? (cesáreas o procesos esteticos)")]
        [MaxLength(500, ErrorMessage = "El campo {0} debe tener máximo {1} carácteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Surgery { get; set; }


        /* Antecedentes familiares
         */

        [Display(Name = "¿Enfermedades familiares? (presión, diabetes, cardiacos, hipertensión ...etc)")]
        [MaxLength(300, ErrorMessage = "El campo {1} debe tener máximo {1} carácteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string CardiacHistory { get; set; }

        /* Estado físico
        */

        [Display(Name = "Tu Peso (en kilogramos)")]
        [MaxLength(10, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Weight { get; set; }

        [Display(Name = "Tu estatura(en centímetros)")]
        [MaxLength(10, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Height { get; set; }

        [Display(Name = "Fractuas")]
        public string Fracture { get; set; }

        [Display(Name = "¿Realizas actividad física?")]
        public bool Sport { get; set; }

        [Display(Name = "Ultimo ciclo menstrual")]
        [MaxLength(20, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres")]
        public string Menstrual { get; set; }

        [Display(Name = "Método anticonceptivo actual")]
        [MaxLength(20, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres")]
        public string MethodMenstrual { get; set; }

        /* Consumo de sustancias
        */
        [Display(Name = "¿Fumas?")]
        public bool Smoke { get; set; }

        [Display(Name = "¿Consumes bebidas alcoholicas?")]
        public bool Beer { get; set; }

        /* Ocupación
        */

        [Display(Name = "Ocupación actual)")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} carácteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Occupation { get; set; }

        /* 
         */
    }
}
