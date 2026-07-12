using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.VisualBasic;
using SearchService.Data;
using SearchService.Models;
using Typesense;
using Typesense.Setup;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.AddServiceDefaults();

var typesenseUri = builder.Configuration.GetValue<string>("services:typesense:typesense:0");
if (string.IsNullOrEmpty(typesenseUri))
{
    throw new InvalidOperationException("Typesense URI is not configured.");
}

var typesenseApiKey = builder.Configuration.GetValue<string>("typesense-api-key");
if (string.IsNullOrEmpty(typesenseApiKey))
{
    throw new InvalidOperationException("Typesense API key is not configured.");
}

var uri = new Uri(typesenseUri);
builder.Services.AddTypesenseClient(config =>
{
    config.ApiKey = typesenseApiKey;
    config.Nodes =
    [
        new(uri.Host, uri.Port.ToString(), uri.Scheme)
    ];
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.MapDefaultEndpoints();

app.MapGet("/search", async (string query, ITypesenseClient client) =>
{
    string? tag = null;
    var tagMatch = Regex.Match(query, @"\[(.*?)\]");
    if (tagMatch.Success)
    {
        tag = tagMatch.Groups[1].Value;
        query = query.Replace(tagMatch.Value, "").Trim();
    }

    var searchParameters = new SearchParameters(query, "title,content");

    if (!string.IsNullOrEmpty(tag))
    {
        searchParameters.FilterBy = $"tags:=[{tag}]";
    }

    try
    {
        var searchResults = await client.Search<SearchQuestion>("questions", searchParameters);
        return Results.Ok(searchResults.Hits.Select(hit => hit.Document));
    }
    catch (TypesenseApiException ex)
    {
        return Results.Problem($"Error searching questions: {ex.Message}");
    }
});

using var scope = app.Services.CreateScope();
var typesenseClient = scope.ServiceProvider.GetRequiredService<ITypesenseClient>();
await SearchInitializer.EnsureIndexExistsAsync(typesenseClient);

app.Run();

