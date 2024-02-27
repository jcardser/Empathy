namespace Empathy.Data.Entities
{
    public class AppointmentDateTimer
    {
        public int Id { get; set; }

        public Appointment Appointment { get; set; }
        public DateTimer DateTimer { get; set; }
    }
}
