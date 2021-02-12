using Shared.Exceptions;
using System;

namespace Domain.Model
{
    public class Todo
    {
        public Todo(string category, string city, string description, DateTime endDate, DateTime startDate, string title, string venue)
        {
            if (string.IsNullOrEmpty(title))
            {
                throw new TodoValidationException();
            }

            Id = Guid.NewGuid();
            Category = category;
            City = city;
            Description = description;
            EndDate = endDate;
            StartDate = startDate;
            Title = title;
            Venue = venue;
        }

        public Guid Id { get; private set; }
        public string Category { get; private set; }
        public string City { get; private set; }
        public string Description { get; private set; }
        public DateTime EndDate { get; private set; }
        public DateTime StartDate { get; private set; }
        public string Title { get; private set; }
        public string Venue { get; private set; }
    }
}
