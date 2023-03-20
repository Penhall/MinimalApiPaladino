using Microsoft.EntityFrameworkCore;
using MinimalApiPaladino.Data;
using MinimalApiPaladino.Endpoints;


var builder = WebApplication.CreateBuilder(args);

builder.AddSwagger();
builder.Services.AddCors();
builder.AddPersistence();

var connectionString = builder.Configuration.GetConnectionString("\"SqliteConnectionString");
builder.Services.AddDbContext<PaladinoDbContext>(option => option.UseSqlite(connectionString));

var app = builder.Build();

app.MapMasterEndpoints();

var environment = app.Environment;


app
    .UseExceptionHandling(environment)
    .UseSwaggerEndpoints()
    .UseCors();


app.Run();