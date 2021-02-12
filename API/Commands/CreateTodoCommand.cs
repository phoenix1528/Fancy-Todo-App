using MediatR;
using Shared;
using System;

namespace API.Commands
{
    public class CreateTodoCommand : IRequest<CommandResponse>
    {
        public string Category { get; private set; }
        public string City { get; private set; }
        public string Description { get; private set; }
        public DateTime EndDate { get; private set; }
        public DateTime StartDate { get; private set; }
        public string Title { get; private set; }
        public string Venue { get; private set; }

        public CreateTodoCommand(CreateTodoDto message)
        {
            if (message is null)
            {
                throw new ArgumentNullException(nameof(message));
            }

            Category = message.Category;
            City = message.City;
            Description = message.Description;
            EndDate = message.EndDate;
            StartDate = message.StartDate;
            Title = message.Title;
            Venue = message.Venue;
        }
    }
}
