using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MvcCocktail.Migrations
{
    /// <inheritdoc />
    public partial class NewStrengthColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Strength",
                table: "Cocktails",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Strength",
                table: "Cocktails");
        }
    }
}
