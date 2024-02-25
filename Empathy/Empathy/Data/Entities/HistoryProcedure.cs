namespace Empathy.Data.Entities
{
    public class HistoryProcedure
    {
        public int Id { get; set; } 
        public History History { get; set; }
        public Procedure Procedure { get; set; }
    }
}
