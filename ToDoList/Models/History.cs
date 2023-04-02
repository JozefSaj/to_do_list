using System.ComponentModel.DataAnnotations;

namespace ToDoList.Models
{
    public class History
    {
        [Key]
        public DateTime HistoryId { get; set; }
        public IEnumerable<Assignment> Assignment { get; set; }
    }
}
