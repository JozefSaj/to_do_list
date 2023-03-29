using Microsoft.EntityFrameworkCore;
namespace ToDoList.Data
{
    public class ApplicationDBContext
    {
        public class ApplicationDbcontext : DbContext
        {

            public ApplicationDbcontext(DbContextOptions<ApplicationDbcontext> options) : base(options)
            {
            }

            //create task table in database
            public DbSet<Models.Task> Tasks { get; set; }

            //create history table in database
            public DbSet<Models.History> Historys { get; set; }

        }
         
        
    }
}
