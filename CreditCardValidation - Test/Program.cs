using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddOpenApi();  // For API documentation

// Add CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", policy =>
    {
        policy.AllowAnyOrigin()    // Allow all origins
              .AllowAnyMethod()    // Allow all HTTP methods
              .AllowAnyHeader();   // Allow all headers
    });
});

var app = builder.Build();

// Enable OpenAPI documentation in development environment
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

// Enable CORS in the application
app.UseCors("AllowAllOrigins");

app.UseHttpsRedirection();

// Define the POST route for validating the credit card
app.MapPost("/api/creditcard/validate", (CreditCard card) =>
{
    bool isValid = ValidateCreditCard(card.CardNumber);  // Replace with actual validation logic

    return Results.Ok(new { isValid });  // Return validation result as JSON response
});

// A basic credit card validation logic placeholder
bool ValidateCreditCard(string cardNumber)
{
    // Add your card validation logic here
    return cardNumber.Length == 16;  // Example: validate if the card number has 16 digits
}

// Test route for weather forecast (not related to card validation, just for testing)
app.MapGet("/weatherforecast", () =>
{
    var summaries = new[] { "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching" };
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");

app.Run();

// Define the WeatherForecast model (for testing)
record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}

// Define the CreditCard model
public class CreditCard
{
    public string CardNumber { get; set; }
}
