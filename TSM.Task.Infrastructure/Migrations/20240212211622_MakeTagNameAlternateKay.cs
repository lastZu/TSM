using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TSM.Task.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MakeTagNameAlternateKay : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddUniqueConstraint(
                name: "ak_tag_name",
                table: "tag",
                column: "name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "ak_tag_name",
                table: "tag");
        }
    }
}
