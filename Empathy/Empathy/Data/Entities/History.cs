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

        [Display(Name = "Resumen historia clinica")]
        [MaxLength(500, ErrorMessage = "El campo {0} debe tener máximo {1} carácteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Summary { get; set; }

        [Display(Name ="Observaciones")]
        [MaxLength(500, ErrorMessage ="El campo {0} debe tener máximo {1} carácteres")]
        [Required(ErrorMessage ="El campo {0} es obligatorio")]
        public string Notes { get; set; }

        [Display(Name ="Diagnostico")]
        [MaxLength(500, ErrorMessage ="El campo {0} debe contener máximo {1} carácteres.")]
        [Required(ErrorMessage ="El campo {0} es obligatorio.")]
        public string Diagnosis { get; set; }

        [Display(Name="Resultado examenes fisicos")]
        [MaxLength(500, ErrorMessage ="El campo {0} debe contener máximo {1} carácteres.")]
        [Required(ErrorMessage ="El campo {0} es obligatorio.")]
        public string PhysicalExam {  get; set; }
        
        //Debe organizarse el motivo de la consulta//
        //Conexión con procedimientos//
        //public ICollection<Procedure> Procedures { get; set; }
    }
}
