namespace Empathy.Data.Entities
{
    public class SedeAppointment
    {
        public int Id { get; set; }

        public Appointment Appointment { get; set; }

        public Sede Sede { get; set; }
       
    }
}
