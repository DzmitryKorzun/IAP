namespace IAP.Infrustructure.Models
{
    public class SprintModel
    {
        public int SprintId { get; set; }
        public string Name { get; set; }
        public string? SprintGoals { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
