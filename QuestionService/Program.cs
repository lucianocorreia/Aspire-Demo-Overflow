var builder = WebApplication.CreateBuilder(args);

var isDevelopment = builder.Environment.IsDevelopment();

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.AddServiceDefaults();
builder.Services.AddAuthorization();
builder.Services.AddAuthentication()
.AddKeycloakJwtBearer("keycloak", "overflow", options =>
{
    options.RequireHttpsMetadata = !isDevelopment;
    options.TokenValidationParameters.ValidAudiences = ["overflow", "account"];
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

app.Run();
