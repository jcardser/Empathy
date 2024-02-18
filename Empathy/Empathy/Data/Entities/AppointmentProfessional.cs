using System.ComponentModel.DataAnnotations;

namespace Empathy.Data.Entities
{
    public class AppointmentProfessional
    {
        //[Key]
        public int Id { get; set; }
        public int AppointmentId { get; set; }
        public Appointment Appointment { get; set; }

        public int ProfessionalId { get; set; }
        public Professional Professional { get; set; }
    }
}
