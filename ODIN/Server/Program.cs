/*
Author: Scott Grizzell
Date: 4/6/2026
Desc: Main backend server for processing requests from frontend. Handles querying 
of SQL db. 
 */

using Server.Data;
using Server.Interfaces;
using Server.Services;
using Microsoft.EntityFrameworkCore;
using Server.Services.Mocks;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<OdinDbContext>(options =>
options.UseSqlServer(connectionString));

// builder.Services.AddScoped<IOffenderService, MockOffenderService>();
builder.Services.AddScoped<IOffenderService, SqlOffenderService>();
builder.Services.AddScoped<IDoc400Service, MockDoc400Service>();

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
