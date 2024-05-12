using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TSM.TaskManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class XXX : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "deadline",
                table: "task",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2024, 1, 18, 0, 44, 47, 647, DateTimeKind.Local).AddTicks(4563));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "deadline",
                table: "task",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 18, 0, 44, 47, 647, DateTimeKind.Local).AddTicks(4563),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);
        }
    }
}
