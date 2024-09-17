namespace PruebaTecnica_Back_end.Domain.Entities
{
    public class TaskItem
    {
        public int TaskId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }  // "Pending", "In Progress", "Completed"
        public int AssignedTo { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    }
}
