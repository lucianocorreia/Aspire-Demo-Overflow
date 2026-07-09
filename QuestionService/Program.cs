using Microsoft.EntityFrameworkCore;
using QuestionService.Data;

var builder = WebApplication.CreateBuilder(args);

var isDevelopment = builder.Environment.IsDevelopment();

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.AddServiceDefaults();
builder.Services.AddAuthentication()
.AddKeycloakJwtBearer("keycloak", "overflow", options =>
{
    options.RequireHttpsMetadata = !isDevelopment;
    options.TokenValidationParameters.ValidAudiences = ["overflow", "account"];
});
builder.Services.AddAuthorization();
builder.AddNpgsqlDbContext<QuestionDbContext>(connectionName: "questionDb");

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapDefaultEndpoints();

using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
try
{
    var context = services.GetRequiredService<QuestionDbContext>();
    await context.Database.MigrateAsync();
}
catch (Exception ex)
{
    var logger = services.GetRequiredService<ILogger<Program>>();
    logger.LogError(ex, "An error occurred while migrating the database.");
    throw;
}

app.Run();
