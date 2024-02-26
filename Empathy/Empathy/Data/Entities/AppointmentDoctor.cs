namespace Empathy.Data.Entities
{
    public class AppointmentDoctor
    {
        public int Id { get; set; }
        public Appointment Appointment { get; set; }
        public Doctor Doctor { get; set; }
    }
}
