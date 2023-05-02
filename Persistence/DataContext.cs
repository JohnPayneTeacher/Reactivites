// FILE: DataContext.cs
// NAME: John Payne
// COURSE: Udemy .NET Basics
// This file contains the attributes for the domain activities entity in the database

using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Activity> Activities { get; set; }
    }
}