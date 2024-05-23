using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FTech.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedCarDescription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "Model", "UpdatedAt" },
                values: new object[,]
                {
                    { 1L, new DateTime(2024, 5, 23, 10, 42, 39, 378, DateTimeKind.Utc).AddTicks(1149), "SUV", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2L, new DateTime(2024, 5, 23, 10, 42, 39, 378, DateTimeKind.Utc).AddTicks(1153), "Sedan", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "Description", "Image", "Name", "Number", "UpdatedAt" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2024, 5, 23, 10, 42, 39, 378, DateTimeKind.Utc).AddTicks(1248), "Description 1", "image1.jpg", "Car 1", "123ABC", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2L, 2L, new DateTime(2024, 5, 23, 10, 42, 39, 378, DateTimeKind.Utc).AddTicks(1251), "Description 2", "image2.jpg", "Car 2", "456DEF", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2L);
        }
    }
}
