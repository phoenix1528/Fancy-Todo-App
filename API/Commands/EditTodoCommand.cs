using MediatR;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Commands
{
    public class EditTodoCommand : IRequest<CommandResponse>
    {
        public Guid Id { get; private set; }
        public string Category { get; private set; }
        public string City { get; private set; }
        public string Description { get; private set; }
        public DateTime EndDate { get; private set; }
        public DateTime StartDate { get; private set; }
        public string Title { get; private set; }
        public string Venue { get; private set; }

        public EditTodoCommand(EditTodoDto message)
        {
            if (message is null)
            {
                throw new ArgumentNullException(nameof(message));
            }

            Id = message.Id;
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
