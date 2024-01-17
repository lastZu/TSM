using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TSM.Task.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Iest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "category",
                columns: table => new
                {
                    id = table.Column<byte>(type: "smallint", nullable: false),
                    name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_category", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "priority",
                columns: table => new
                {
                    id = table.Column<byte>(type: "smallint", nullable: false),
                    name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_priority", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "task",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    title = table.Column<string>(type: "text", nullable: false),
                    deadline = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValue: new DateTime(2024, 1, 18, 0, 39, 45, 320, DateTimeKind.Local).AddTicks(8004)),
                    comment = table.Column<string>(type: "character varying(1024)", maxLength: 1024, nullable: true),
                    category_id = table.Column<byte>(type: "smallint", nullable: false),
                    priority_id = table.Column<byte>(type: "smallint", nullable: false),
                    my_property = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_task", x => x.id);
                    table.ForeignKey(
                        name: "fk_task_category_category_id",
                        column: x => x.category_id,
                        principalTable: "category",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_task_priority_priority_id",
                        column: x => x.priority_id,
                        principalTable: "priority",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_task_category_id",
                table: "task",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "ix_task_priority_id",
                table: "task",
                column: "priority_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "task");

            migrationBuilder.DropTable(
                name: "category");

            migrationBuilder.DropTable(
                name: "priority");
        }
    }
}
