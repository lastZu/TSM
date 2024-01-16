using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TSM.Task.Api.Migrations
{
    /// <inheritdoc />
    public partial class Test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "deadline",
                table: "task",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 17, 1, 11, 16, 460, DateTimeKind.Local).AddTicks(3310),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2024, 1, 17, 1, 2, 1, 818, DateTimeKind.Local).AddTicks(5752));

            migrationBuilder.AddColumn<int>(
                name: "test",
                table: "task",
                type: "integer",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "test",
                table: "task");

            migrationBuilder.AlterColumn<DateTime>(
                name: "deadline",
                table: "task",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 17, 1, 2, 1, 818, DateTimeKind.Local).AddTicks(5752),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2024, 1, 17, 1, 11, 16, 460, DateTimeKind.Local).AddTicks(3310));
        }
    }
}
