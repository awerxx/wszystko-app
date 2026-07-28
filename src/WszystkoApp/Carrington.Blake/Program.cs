using Carrington.Blake.Endpoints;
using Carrington.Blake.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IAccountStore, InMemoryAccountStore>();
builder.Services.AddOpenApi();
builder.Services.ConfigureHttpJsonOptions(options =>
    options.SerializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter()));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapAccountEndpoints();

app.Run();
