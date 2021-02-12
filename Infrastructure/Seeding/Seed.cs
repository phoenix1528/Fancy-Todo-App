using Domain.Model;
using Infrastructure.DB;
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
                    new Todo(
                        "Sport",
                        "Klosterneuburg",
                        "Laufen 2km",
                        new DateTime(2021, 2, 7, 20, 30, 00),
                        new DateTime(2021, 2, 7, 20, 52, 00),
                        "Beginnertraining",
                        "Auwald"
                    ),
                    new Todo
                    (
                        "Work",
                        "Wien",
                        "Arbeiten im Büro",
                        new DateTime(2021, 2, 1, 9, 30, 00),
                        new DateTime(2021, 2, 1, 17, 00, 00),
                        "Arbeiten bei der Post",
                        "Office"
                    ),
                    new Todo
                    (
                       "Sport",
                        "Klosterneuburg",
                        "Training mit Klimmzugstange",
                        new DateTime(2021, 2, 7, 20, 00, 00),
                        new DateTime(2021, 2, 7, 20, 15, 00),
                        "Einsteigertraining",
                        "Auwald"
                    ),
                    new Todo
                    (
                        "Sport",
                        "Klosterneuburg",
                        "Training mit Klimmzugstange",
                        new DateTime(2021, 2, 9, 15, 00, 00),
                        new DateTime(2021, 2, 9, 15, 15, 00),
                        "Einsteigertraining",
                        "Office"
                    ),
                    new Todo
                    (
                        "Sport",
                        "Klosterneuburg",
                        "Kurzes Aufwärmen mit Fahrrad und danach Laufen 2km",
                        new DateTime(2021, 2, 7, 20, 20, 00),
                        new DateTime(2021, 2, 7, 20, 55, 00),
                        "Einsteigertraining",
                        "Auwald"
                    )
                };

                context.Todos.AddRange(todos);
                context.SaveChanges();
            }
        }
    }
}
