
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoList.Models
{
    public class Task
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Details { get; set; }
        public bool Checked { get; set; }

        [ForeignKey("HistoryRefId")]
        public DateTime MyProperty { get; set; }
    }
}
