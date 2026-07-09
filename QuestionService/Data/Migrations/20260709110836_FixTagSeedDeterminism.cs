using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuestionService.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixTagSeedDeterminism : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: "aspire",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 7, 9, 8, 48, 44, 0, DateTimeKind.Utc), new DateTime(2026, 7, 9, 8, 48, 44, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: "dotnet",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 7, 9, 8, 48, 44, 0, DateTimeKind.Utc), new DateTime(2026, 7, 9, 8, 48, 44, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: "ef-core",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 7, 9, 8, 48, 44, 0, DateTimeKind.Utc), new DateTime(2026, 7, 9, 8, 48, 44, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: "keycloak",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 7, 9, 8, 48, 44, 0, DateTimeKind.Utc), new DateTime(2026, 7, 9, 8, 48, 44, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: "microservices",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 7, 9, 8, 48, 44, 0, DateTimeKind.Utc), new DateTime(2026, 7, 9, 8, 48, 44, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: "nextjs",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 7, 9, 8, 48, 44, 0, DateTimeKind.Utc), new DateTime(2026, 7, 9, 8, 48, 44, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: "postgresql",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 7, 9, 8, 48, 44, 0, DateTimeKind.Utc), new DateTime(2026, 7, 9, 8, 48, 44, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: "signalr",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 7, 9, 8, 48, 44, 0, DateTimeKind.Utc), new DateTime(2026, 7, 9, 8, 48, 44, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: "typescript",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 7, 9, 8, 48, 44, 0, DateTimeKind.Utc), new DateTime(2026, 7, 9, 8, 48, 44, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: "wolverine",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 7, 9, 8, 48, 44, 0, DateTimeKind.Utc), new DateTime(2026, 7, 9, 8, 48, 44, 0, DateTimeKind.Utc) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: "aspire",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 7, 9, 8, 48, 44, 715, DateTimeKind.Utc).AddTicks(6440), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: "dotnet",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 7, 9, 8, 48, 44, 715, DateTimeKind.Utc).AddTicks(6840), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: "ef-core",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 7, 9, 8, 48, 44, 715, DateTimeKind.Utc).AddTicks(6840), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: "keycloak",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 7, 9, 8, 48, 44, 715, DateTimeKind.Utc).AddTicks(6830), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: "microservices",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 7, 9, 8, 48, 44, 715, DateTimeKind.Utc).AddTicks(6850), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: "nextjs",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 7, 9, 8, 48, 44, 715, DateTimeKind.Utc).AddTicks(6850), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: "postgresql",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 7, 9, 8, 48, 44, 715, DateTimeKind.Utc).AddTicks(6840), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: "signalr",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 7, 9, 8, 48, 44, 715, DateTimeKind.Utc).AddTicks(6850), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: "typescript",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 7, 9, 8, 48, 44, 715, DateTimeKind.Utc).AddTicks(6850), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: "wolverine",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 7, 9, 8, 48, 44, 715, DateTimeKind.Utc).AddTicks(6840), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
