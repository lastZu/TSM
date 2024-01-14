using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TSM.Task.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    id = table.Column<byte>(type: "smallint", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_category", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Priority",
                columns: table => new
                {
                    id = table.Column<byte>(type: "smallint", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_priority", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Task",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    title = table.Column<string>(type: "text", nullable: false),
                    dedline = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValue: new DateTime(2024, 1, 14, 23, 30, 25, 644, DateTimeKind.Local).AddTicks(70)),
                    comment = table.Column<string>(type: "character varying(1024)", maxLength: 1024, nullable: true),
                    category_id = table.Column<byte>(type: "smallint", nullable: false),
                    priority_id = table.Column<byte>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_task", x => x.id);
                    table.ForeignKey(
                        name: "fk_task_category_category_id",
                        column: x => x.category_id,
                        principalTable: "Category",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_task_priority_priority_id",
                        column: x => x.priority_id,
                        principalTable: "Priority",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "ix_task_category_id",
                table: "Task",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "ix_task_priority_id",
                table: "Task",
                column: "priority_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Task");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Priority");
        }
    }
}
