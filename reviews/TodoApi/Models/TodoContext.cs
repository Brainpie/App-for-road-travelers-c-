using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;


namespace Reviews.Models
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options)
            : base(options)
        {
        }

        public DbSet<Reviews> Reviews { get; set; } = null!;
    }
}