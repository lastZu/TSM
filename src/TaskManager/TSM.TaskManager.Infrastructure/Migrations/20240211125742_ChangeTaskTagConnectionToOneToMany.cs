using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TSM.TaskManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeTaskTagConnectionToOneToMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tag_task");

            migrationBuilder.AddColumn<Guid>(
                name: "tag_id",
                table: "task",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "ix_task_tag_id",
                table: "task",
                column: "tag_id");

            migrationBuilder.AddForeignKey(
                name: "fk_task_tag_tag_id",
                table: "task",
                column: "tag_id",
                principalTable: "tag",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_task_tag_tag_id",
                table: "task");

            migrationBuilder.DropIndex(
                name: "ix_task_tag_id",
                table: "task");

            migrationBuilder.DropColumn(
                name: "tag_id",
                table: "task");

            migrationBuilder.CreateTable(
                name: "tag_task",
                columns: table => new
                {
                    tags_id = table.Column<Guid>(type: "uuid", nullable: false),
                    tasks_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_tag_task", x => new { x.tags_id, x.tasks_id });
                    table.ForeignKey(
                        name: "fk_tag_task_tag_tags_id",
                        column: x => x.tags_id,
                        principalTable: "tag",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_tag_task_task_tasks_id",
                        column: x => x.tasks_id,
                        principalTable: "task",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_tag_task_tasks_id",
                table: "tag_task",
                column: "tasks_id");
        }
    }
}
