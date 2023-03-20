using MinimalApiPaladino.Endpoints;


var builder = WebApplication.CreateBuilder(args);

builder.AddSwagger();
builder.Services.AddCors();
builder.AddPersistence();

var app = builder.Build();

app.MapMasterEndpoints();

var environment = app.Environment;


app
    .UseExceptionHandling(environment)
    .UseSwaggerEndpoints()
    .UseCors();


app.Run();