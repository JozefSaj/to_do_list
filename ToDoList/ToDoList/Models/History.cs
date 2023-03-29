namespace ToDoList.Models
{
    public class History
    {
        public DateTime HistoryId { get; set; }
        public IEnumerable<Task> Tasks { get; set; }
    }
}
