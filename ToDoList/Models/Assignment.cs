
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoList.Models
{
    public class Assignment
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Details { get; set; }

        [ForeignKey("History")]
        public String HistoryId { get; set; }
        
    }
}
