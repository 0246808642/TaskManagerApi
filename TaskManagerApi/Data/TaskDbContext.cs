using Microsoft.EntityFrameworkCore;
using TaskManagerApi.Models;

namespace TaskManagerApi.Data
{
    public class TaskDbContext : DbContext
    {
        public TaskDbContext(DbContextOptions<TaskDbContext> context):base(context)
        {
            
        }

        public DbSet<TaskOn> Tasks { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
