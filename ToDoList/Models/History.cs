using System.ComponentModel.DataAnnotations;

namespace ToDoList.Models
{
    public class History
    {
        [Key]
        public string HistoryId { get; set; }
    }
}
