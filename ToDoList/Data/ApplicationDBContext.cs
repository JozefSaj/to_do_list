using Microsoft.EntityFrameworkCore;
namespace ToDoList.Data
{
    
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        //create task table in database
        public DbSet<Models.Assignment> Assignments { get; set; }

        //create history table in database
        public DbSet<Models.History> Historys { get; set; }

    }
         
        
    
}
