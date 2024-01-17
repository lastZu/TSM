using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TSM.Task.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class reIest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "my_property",
                table: "task");

            migrationBuilder.AlterColumn<DateTime>(
                name: "deadline",
                table: "task",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 18, 0, 44, 47, 647, DateTimeKind.Local).AddTicks(4563),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2024, 1, 18, 0, 39, 45, 320, DateTimeKind.Local).AddTicks(8004));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "deadline",
                table: "task",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 18, 0, 39, 45, 320, DateTimeKind.Local).AddTicks(8004),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2024, 1, 18, 0, 44, 47, 647, DateTimeKind.Local).AddTicks(4563));

            migrationBuilder.AddColumn<int>(
                name: "my_property",
                table: "task",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
