using Domain;
using Microsoft.EntityFrameworkCore;
using System;

namespace Infrastructure
{
    public class DataContext : DbContext
    {

        public DbSet<Todo> Todos { get; set; } = null!;

        public DataContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //TODO: add seeding for todo entity
            //builder.Entity<Todo>()
            //    .HasData(
            //        new Todo
            //        {
            //            Id = Guid.NewGuid(),
                        
            //            Name = "value 101"
            //        },
            //        new Todo
            //        {
            //            Id = Guid.NewGuid(),
            //            Name = "value 102"
            //        },
            //        new Todo
            //        {
            //            Id = Guid.NewGuid(),
            //            Name = "value 103"
            //        }
            //    );
        }
    }
}
