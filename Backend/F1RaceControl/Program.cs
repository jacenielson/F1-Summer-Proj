using Microsoft.AspNetCore.Builder;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddHttpClient("OpenF1", client =>
{
    client.BaseAddress = new Uri("https://api.openf1.org/v1/");
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
    });
}


app.UseHttpsRedirection();

app.MapControllers();

app.Run();
