namespace Empathy.Data.Entities
{
    public class AppointmentCampus
    {
        public int Id { get; set; }
        public Appointment Appointment { get; set; }
        public Campus Campus { get; set; }
    }
}
