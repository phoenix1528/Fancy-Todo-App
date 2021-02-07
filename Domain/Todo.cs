using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Todo
    {
        public Guid Id { get; set; }
        public string Category { get; set; }
        public string City { get; set; }
        public string Description { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime StartDate { get; set; }
        public string Title { get; set; }
        public string Venue { get; set; }
    }
}
