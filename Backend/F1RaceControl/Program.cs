using Microsoft.AspNetCore.Builder;
using F1RaceControl.Services;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddHttpClient("OpenF1", client =>
{
    var baseUrl = builder.Configuration["OpenF1Settings:BaseUrl"];
    client.BaseAddress = new Uri(baseUrl ?? throw new InvalidOperationException("OpenF1 BaseUrl is missing from config."));
});
builder.Services.AddScoped<IF1Service, F1Service>();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

//This must follow adding the client
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "F1 Race Control API v1");
        options.RoutePrefix = string.Empty;
    });
}


app.UseHttpsRedirection();

//This needs to be bettween redirection and controllers
app.UseCors();

app.MapControllers();

app.Run();
