using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TSM.TaskManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedPrioritesAndCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "category",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { (byte)0, "Something isn't working" },
                    { (byte)1, "New feature" },
                    { (byte)2, "Further information is requested" }
                });

            migrationBuilder.InsertData(
                table: "priority",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { (byte)0, "Low Priority" },
                    { (byte)1, "Medium Priority" },
                    { (byte)2, "Highest Priority" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "category",
                keyColumn: "id",
                keyValue: (byte)0);

            migrationBuilder.DeleteData(
                table: "category",
                keyColumn: "id",
                keyValue: (byte)1);

            migrationBuilder.DeleteData(
                table: "category",
                keyColumn: "id",
                keyValue: (byte)2);

            migrationBuilder.DeleteData(
                table: "priority",
                keyColumn: "id",
                keyValue: (byte)0);

            migrationBuilder.DeleteData(
                table: "priority",
                keyColumn: "id",
                keyValue: (byte)1);

            migrationBuilder.DeleteData(
                table: "priority",
                keyColumn: "id",
                keyValue: (byte)2);
        }
    }
}
