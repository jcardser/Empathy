namespace Empathy.Data.Entities
{
    public class SedeProfessional
    {
        public int Id { get; set; }

        public Sede Sede { get; set; }
        public Professional Professional { get; set; }

    }
}
