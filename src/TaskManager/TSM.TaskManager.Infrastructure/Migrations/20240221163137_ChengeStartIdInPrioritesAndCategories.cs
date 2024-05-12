using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TSM.TaskManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChengeStartIdInPrioritesAndCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "category",
                keyColumn: "id",
                keyValue: (byte)0);

            migrationBuilder.DeleteData(
                table: "priority",
                keyColumn: "id",
                keyValue: (byte)0);

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: (byte)1,
                column: "name",
                value: "Something isn't working");

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: (byte)2,
                column: "name",
                value: "New feature");

            migrationBuilder.InsertData(
                table: "category",
                columns: new[] { "id", "name" },
                values: new object[] { (byte)3, "Further information is requested" });

            migrationBuilder.UpdateData(
                table: "priority",
                keyColumn: "id",
                keyValue: (byte)1,
                column: "name",
                value: "Low Priority");

            migrationBuilder.UpdateData(
                table: "priority",
                keyColumn: "id",
                keyValue: (byte)2,
                column: "name",
                value: "Medium Priority");

            migrationBuilder.InsertData(
                table: "priority",
                columns: new[] { "id", "name" },
                values: new object[] { (byte)3, "Highest Priority" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "category",
                keyColumn: "id",
                keyValue: (byte)3);

            migrationBuilder.DeleteData(
                table: "priority",
                keyColumn: "id",
                keyValue: (byte)3);

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: (byte)1,
                column: "name",
                value: "New feature");

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "id",
                keyValue: (byte)2,
                column: "name",
                value: "Further information is requested");

            migrationBuilder.InsertData(
                table: "category",
                columns: new[] { "id", "name" },
                values: new object[] { (byte)0, "Something isn't working" });

            migrationBuilder.UpdateData(
                table: "priority",
                keyColumn: "id",
                keyValue: (byte)1,
                column: "name",
                value: "Medium Priority");

            migrationBuilder.UpdateData(
                table: "priority",
                keyColumn: "id",
                keyValue: (byte)2,
                column: "name",
                value: "Highest Priority");

            migrationBuilder.InsertData(
                table: "priority",
                columns: new[] { "id", "name" },
                values: new object[] { (byte)0, "Low Priority" });
        }
    }
}
