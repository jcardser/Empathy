using Empathy.Data.Entities;
using System.ComponentModel.DataAnnotations;

public class AppointmentUser
{
    [Key]
    public int Id { get; set; }

    public int AppointmentId { get; set; }
    public Appointment Appointment { get; set; }

    public string UserId { get; set; }
    public User User { get; set; }
}