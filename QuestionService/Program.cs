using Microsoft.EntityFrameworkCore;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using QuestionService.Data;
using Wolverine;
using Wolverine.RabbitMQ;

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

builder.Services.AddOpenTelemetry().WithTracing(traceProviderBuilder =>
{
    traceProviderBuilder
        .SetResourceBuilder(ResourceBuilder.CreateDefault().AddService(builder.Environment.ApplicationName))
        .AddSource("Wolverine");
});


builder.Host.UseWolverine(options =>
{
    options.UseRabbitMqUsingNamedConnection("messaging").AutoProvision();
    options.PublishAllMessages().ToRabbitExchange("questions");
});


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
