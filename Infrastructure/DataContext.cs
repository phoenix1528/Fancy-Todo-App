﻿using Domain;
using Microsoft.EntityFrameworkCore;
using System;

namespace Infrastructure
{
    public class DataContext : DbContext
    {

        public DbSet<Value> Values { get; set; } = null!;

        public DataContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Value>()
                .HasData(
                    new Value
                    {
                        Id = 1,
                        Name = "value 101"
                    },
                    new Value
                    {
                        Id = 2,
                        Name = "value 102"
                    },
                    new Value
                    {
                        Id = 3,
                        Name = "value 103"
                    }
                );
        }
    }
}