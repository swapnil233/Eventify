using API.Extensions;
using Microsoft.EntityFrameworkCore;
using Persistence;

var builder = WebApplication.CreateBuilder(args);

// Enable controllers
builder.Services.AddControllers();

// Add all services via extension method
builder.Services.AddApplicationServices(builder.Configuration);

var app = builder.Build();

// Redirect to HTTPS
app.UseHttpsRedirection();

// Use CORS
app.UseCors("CorsPolicy");

// Enable authorization capabilities
app.UseAuthorization();

// Registers endpoints
app.MapControllers();

// Destroy & clean memory after executing the scoped services above
using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;

try
{
    var context = services.GetRequiredService<DataContext>();
    context.Database.Migrate();

    // Seed the DB
    await Seed.SeedData(context);
}
catch (Exception ex)
{
    var logger = services.GetRequiredService<ILogger<Program>>();
    logger.LogError(ex, "An error occured during migration");
}

app.Run();