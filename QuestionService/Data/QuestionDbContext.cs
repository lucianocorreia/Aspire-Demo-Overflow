using Microsoft.EntityFrameworkCore;
using QuestionService.Models;

namespace QuestionService.Data;

public class QuestionDbContext(DbContextOptions<QuestionDbContext> options) : DbContext(options)
{
    private static readonly DateTime SeedCreatedAt = new(2026, 7, 9, 8, 48, 44, DateTimeKind.Utc);

    public DbSet<Question> Questions { get; set; }
    public DbSet<Tag> Tags { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Tag>()
            .HasData(
                new Tag
                {
                    Id = "aspire",
                    CreatedAt = SeedCreatedAt,
                    UpdatedAt = SeedCreatedAt,
                    Name = "Aspire",
                    Slug = "aspire",
                    Description =
                        "A composable, opinionated stack for building distributed apps with .NET. Provides dashboard, diagnostics, and simplified service orchestration."
                },
                new Tag
                {
                    Id = "keycloak",
                    CreatedAt = SeedCreatedAt,
                    UpdatedAt = SeedCreatedAt,
                    Name = "Keycloak",
                    Slug = "keycloak",
                    Description =
                        "An open-source identity and access management solution for modern applications and services. Integrates easily with OAuth2, OIDC, and SSO."
                },
                new Tag
                {
                    Id = "dotnet",
                    CreatedAt = SeedCreatedAt,
                    UpdatedAt = SeedCreatedAt,
                    Name = ".NET",
                    Slug = "dotnet",
                    Description =
                        "A modern, cross-platform development platform for building cloud, web, mobile, desktop, and IoT apps using C# and F#."
                },
                new Tag
                {
                    Id = "ef-core",
                    CreatedAt = SeedCreatedAt,
                    UpdatedAt = SeedCreatedAt,
                    Name = "Entity Framework Core",
                    Slug = "ef-core",
                    Description =
                        "A modern object-database mapper (ORM) for .NET that supports LINQ, change tracking, and migrations for working with relational databases."
                },
                new Tag
                {
                    Id = "wolverine",
                    CreatedAt = SeedCreatedAt,
                    UpdatedAt = SeedCreatedAt,
                    Name = "Wolverine",
                    Slug = "wolverine",
                    Description =
                        "A high-performance messaging and command-handling framework for .NET with built-in support for Mediator, queues, retries, and durable messaging."
                },
                new Tag
                {
                    Id = "postgresql",
                    CreatedAt = SeedCreatedAt,
                    UpdatedAt = SeedCreatedAt,
                    Name = "PostgreSQL",
                    Slug = "postgresql",
                    Description =
                        "A powerful, open-source object-relational database system known for reliability, feature richness, and standards compliance."
                },
                new Tag
                {
                    Id = "signalr",
                    CreatedAt = SeedCreatedAt,
                    UpdatedAt = SeedCreatedAt,
                    Name = "SignalR",
                    Slug = "signalr",
                    Description =
                        "A real-time communication library for ASP.NET that enables server-to-client messaging over WebSockets, long polling, and more."
                },
                new Tag
                {
                    Id = "nextjs",
                    CreatedAt = SeedCreatedAt,
                    UpdatedAt = SeedCreatedAt,
                    Name = "Next.js",
                    Slug = "nextjs",
                    Description =
                        "A React framework for building fast, full-stack web apps with server-side rendering, routing, and static site generation."
                },
                new Tag
                {
                    Id = "typescript",
                    CreatedAt = SeedCreatedAt,
                    UpdatedAt = SeedCreatedAt,
                    Name = "TypeScript",
                    Slug = "typescript",
                    Description =
                        "A statically typed superset of JavaScript that compiles to clean JavaScript. Helps build large-scale apps with tooling support."
                },
                new Tag
                {
                    Id = "microservices",
                    CreatedAt = SeedCreatedAt,
                    UpdatedAt = SeedCreatedAt,
                    Name = "Microservices",
                    Slug = "microservices",
                    Description =
                        "An architectural style that structures an application as a collection of loosely coupled services that can be independently deployed and scaled."
                }
            );
    }
}
