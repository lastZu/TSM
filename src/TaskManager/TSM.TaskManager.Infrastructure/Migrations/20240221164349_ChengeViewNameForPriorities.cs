using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TSM.TaskManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChengeViewNameForPriorities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "priority",
                keyColumn: "id",
                keyValue: (byte)1,
                column: "name",
                value: "Low");

            migrationBuilder.UpdateData(
                table: "priority",
                keyColumn: "id",
                keyValue: (byte)2,
                column: "name",
                value: "Medium");

            migrationBuilder.UpdateData(
                table: "priority",
                keyColumn: "id",
                keyValue: (byte)3,
                column: "name",
                value: "Highest");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.UpdateData(
                table: "priority",
                keyColumn: "id",
                keyValue: (byte)3,
                column: "name",
                value: "Highest Priority");
        }
    }
}
