using Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DB
{
    public class DataContext : DbContext
    {
        public DbSet<Todo> Todos { get; set; } = null!;

        public DataContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Todo>()
                .Property(t => t.Category)
                .HasMaxLength(30);
            builder.Entity<Todo>()
                .Property(t => t.City)
                .HasMaxLength(50);
            builder.Entity<Todo>()
                .Property(t => t.Description)
                .HasMaxLength(256);
            builder.Entity<Todo>()
                .Property(t => t.Venue)
                .HasMaxLength(50);
            builder.Entity<Todo>()
                .Property(t => t.Title)
                .IsRequired()
                .HasMaxLength(256);

        }
    }
}
