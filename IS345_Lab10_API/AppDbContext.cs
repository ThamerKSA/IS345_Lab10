using Microsoft.EntityFrameworkCore;
using IS345_Lab10_API.Models;

namespace IS345_Lab10_API
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
    }
}
