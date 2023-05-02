// FILE: Activity.cs
// NAME: John Payne
// COURSE: Udemy .NET Basics
// This file contains the attributes for the domain activity entity in the database

namespace Domain
{
    public class Activity //relates to a table in the database
    {
        //each relates to a column in the table
        public Guid Id { get; set; }

        public string Title { get; set; }

        public DateTime Date { get; set; }

        public string Description { get; set; }

        public string Category { get; set; }

        public string City { get; set; }

        public string Venue { get; set; }
    }
}