
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
        public string? Details { get; set; } = "";
        public bool Checked { get; set; } = false;

        [ForeignKey("History")]
        public string HistoryId { get; set; } = DateTime.Now.ToString("d.M.yyyy");
        
    }
}
