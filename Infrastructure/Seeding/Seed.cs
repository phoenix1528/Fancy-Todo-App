using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Seeding
{
    public class Seed
    {
        public static void SeedData(DataContext context)
        {
            if (!context.Todos.Any())
            {
                var todos = new List<Todo>
                {
                    new Todo
                    {
                        Id = Guid.NewGuid(),
                        Category = "Sports Activity",
                        City = "Klosterneuburg",
                        Venue = "Laufen 2km",
                        Description = "Laufen 2km",
                        StartDate = new DateTime(2021, 2, 7, 20, 30, 00),
                        EndDate = new DateTime(2021, 2, 7, 20, 52, 00),
                    },
                    new Todo
                    {
                        Id = Guid.NewGuid(),
                        Category = "Work",
                        City = "Wien",
                        Venue = "Working at the office",
                        Description = "Arbeiten im Büro",
                        StartDate = new DateTime(2021, 2, 1, 9, 30, 00),
                        EndDate = new DateTime(2021, 2, 1, 17, 00, 00),
                    },
                    new Todo
                    {
                        Id = Guid.NewGuid(),
                        Category = "Sports Activity",
                        City = "Klosterneuburg",
                        Venue = "Training mit Klimmzugstange",
                        Description = "Training mit Klimmzugstange",
                        StartDate = new DateTime(2021, 2, 7, 20, 00, 00),
                        EndDate = new DateTime(2021, 2, 7, 20, 15, 00),
                    },
                    new Todo
                    {
                        Id = Guid.NewGuid(),
                        Category = "Sports Activity",
                        City = "Klosterneuburg",
                        Venue = "Training mit Klimmzugstange",
                        Description = "Training mit Klimmzugstange",
                        StartDate = new DateTime(2021, 2, 9, 15, 00, 00),
                        EndDate = new DateTime(2021, 2, 9, 15, 15, 00),
                    },
                    new Todo
                    {
                        Id = Guid.NewGuid(),
                        Category = "Sports Activity",
                        City = "Klosterneuburg",
                        Venue = "Training mit Klimmzugstange",
                        Description = "Kurzes Aufwärmen mit Fahrrad und danach Laufen 2km",
                        StartDate = new DateTime(2021, 2, 7, 20, 20, 00),
                        EndDate = new DateTime(2021, 2, 7, 20, 55, 00),
                    }
                };

                context.Todos.AddRange(todos);
                context.SaveChanges();
            }
        }
    }
}
