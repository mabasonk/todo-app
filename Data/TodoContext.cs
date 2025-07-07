using Microsoft.EntityFrameworkCore;
using todoApi.Models;

namespace todoApi.Data
{
    public class TodoContext : DbContext
    {
        public DbSet<TodoItem> TodoItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TodoItem>().HasData(
                new TodoItem { Id = 1, Name = "Learn EF Core", IsComplete = false },
                new TodoItem { Id = 2, Name = "Build Todo API", IsComplete = true },
                new TodoItem { Id = 3, Name = "Test API", IsComplete = false }
            );
        }
    }
}