using System.ComponentModel.DataAnnotations;

namespace ToDoList.Models
{
    public class History
    {
        [Key]
        public String HistoryId { get; set; } = DateTime.Now.ToString("dd-MM-yyyy");
        public IEnumerable<Assignment> Assignment { get; set; }
    }
}
