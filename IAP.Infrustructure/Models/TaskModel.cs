namespace IAP.Infrustructure.Models
{
    public class TaskModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateTimeCreated { get; set; }
        public DateTime DateTimeChanged { get; set; }
        public int Status { get; set; }
        public int IdAssisgnedUser { get; set; }
        public int IdSprint { get; set; }
    }
}
