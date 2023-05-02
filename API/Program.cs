// FILE: Program.cs
// NAME: John Payne
// COURSE: Udemy .NET Basics
// This file contains the builder, services, middleware, and methods used to run the main logic of the Reactivites application

using Microsoft.EntityFrameworkCore;
using Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(opt =>
{
    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

// Configure the HTTP request pipeline. 
    // "Middleware" - Things that can something with the HTTP request on its way in or out
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// The following creates a scope for the services that will be cleaned out by the "using"
using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;

// Try to create the database, otherwise log an error
try
{
    var context = services.GetRequiredService<DataContext>();
    await context.Database.MigrateAsync();
    await Seed.SeedData(context);
}
catch (Exception ex)
{
   var logger = services.GetRequiredService<ILogger<Program>>();
   logger.LogError(ex, "An error has occured during migration");
}

app.Run();