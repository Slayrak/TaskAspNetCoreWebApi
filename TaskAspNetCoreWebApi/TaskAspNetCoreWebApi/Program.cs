using Bogus;
using FluentValidation;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using TaskAspNetCoreWebApi.Business.MapperProfiles;
using TaskAspNetCoreWebApi.Business.Services;
using TaskAspNetCoreWebApi.Business.Validators;
using TaskAspNetCoreWebApi.DataAccess.Repositories;
using TaskAspNetCoreWebApi.Domain.DTO;
using TaskAspNetCoreWebApi.Domain.Interfaces;
using TaskAspNetCoreWebApi.Domain.Interfaces.Services;
using TaskAspNetCoreWebApi.Domain.OptionsClasses;
using TaskAspNetCoreWebApi.Middlewares;
using TaskAspNetCoreWebApi.ServiceConfigurations;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IRatingRepository, RatingRepository>();
builder.Services.AddScoped<IReviewRepository, ReviewRepository>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDataAccess(builder.Configuration);

builder.Services.AddScoped<IBookService, BookService>();

builder.Services.AddAutoMapper(typeof(BookProfile).Assembly);
builder.Services.AddValidatorsFromAssemblyContaining<RateValidator>(ServiceLifetime.Transient);

builder.Services.AddTransient<ErrorHandlingMiddleware>();
builder.Services.AddTransient<LoggingMiddleware>();

builder.Services.Configure<Secret>(builder.Configuration.GetSection("Secret"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MigrateDatabase();

app.UseAuthorization();

app.UseMiddleware<LoggingMiddleware>();
app.UseMiddleware<ErrorHandlingMiddleware>();

app.MapControllers();

app.Run();
