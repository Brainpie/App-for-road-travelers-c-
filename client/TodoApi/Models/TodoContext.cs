using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;


namespace Client.Models
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options)
            : base(options)
        {
        }

        public DbSet<Client> Client { get; set; } = null!;
    }
}