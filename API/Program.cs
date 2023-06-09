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

//Defines the Connection String for the database to work
{
    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});

//Sets the Cors policy for the page so that React can access the API
builder.Services.AddCors(opt =>
{
    opt.AddPolicy("CorsPolicy", policy =>
    {
        policy.AllowAnyMethod().AllowAnyHeader().WithOrigins("http://localhost:3000");
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline. 
    // "Middleware" - Things that can something with the HTTP request on its way in or out
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");

//app.UseHttpsRedirection(); - he deleted this in module 1

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