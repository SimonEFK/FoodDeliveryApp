using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodDeliveryApp.Server.Migrations
{
    /// <inheritdoc />
    public partial class itemImageUrlField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "image_url",
                table: "items",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "image_url",
                table: "items");
        }
    }
}
