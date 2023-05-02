// FILE: ActivitesController.cs
// NAME: John Payne
// COURSE: Udemy .NET Basics
// This is the API Controller for the activities portion of the application

using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers
{
    public class ActivitesController : BaseApiController
    {
        //// Dependency Injection
        ///
        
        private readonly DataContext _context;

        public ActivitesController(DataContext context)
        {
            _context = context;
        }

        //// Endpoints
        ///
        
        [HttpGet] // api/activites
        public async Task<ActionResult<List<Activity>>> GetActivites()
        {
            return await _context.Activities.ToListAsync();
        }

        [HttpGet("{id}")] // api/activites/*guid*
        public async Task<ActionResult<Activity>> GetActivity(Guid id)
        {
            return await _context.Activities.FindAsync(id);
        }
    }
}