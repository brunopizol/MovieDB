using MovieDB.Infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using MovieDB.Domain.Services;
using MovieDB.Infra.Repositories;
using MovieDB.Domain.Repositories;
using MovieDB.Domain.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionstring = builder.Configuration.GetConnectionString("DefaultConnection");


//string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
//builder.Services.AddDbContext<MyContextDatabase>(options =>
//    options.UseMySql(connectionString, new MariaDbServerVersion(new Version(10, 4, 21))));

builder.Services.AddDbContext<MyContextDatabase>(options =>
{
    options.UseMySql(connectionstring, ServerVersion.AutoDetect(connectionstring));
}, ServiceLifetime.Transient);

builder.Services.AddScoped<MovieService>();
builder.Services.AddScoped<DirectorService>();
builder.Services.AddScoped<ActorService>();

builder.Services.AddControllers()
    .AddControllersAsServices();

builder.Services.AddScoped(typeof(IRepository<Movie>), typeof(MovieRepository));
builder.Services.AddScoped(typeof(IRepository<Actor>), typeof(ActorRepository));
builder.Services.AddScoped(typeof(IRepository<Director>), typeof(DirectorRepository));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
