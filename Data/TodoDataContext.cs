using Microsoft.EntityFrameworkCore;
using signin_signup_backend.Models;

namespace signin_signup_backend.Data
{
    public class TodoDataContext : DbContext
    {
        public TodoDataContext(DbContextOptions<TodoDataContext> options)
            : base(options)
        {
        }

        public DbSet<TodoItem> TodoItems { get; set; }
    }
}