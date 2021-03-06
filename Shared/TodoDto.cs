﻿using System;

namespace Shared
{
    public class TodoDto
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
