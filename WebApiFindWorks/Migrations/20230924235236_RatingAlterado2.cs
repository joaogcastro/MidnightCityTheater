using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiFindWorks.Migrations
{
    /// <inheritdoc />
    public partial class RatingAlterado2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Comentario",
                table: "Rating",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Comentario",
                table: "Rating");
        }
    }
}
