using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Luxelane.Migrations
{
    /// <inheritdoc />
    public partial class AddCategoryAndProductCegory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                table: "product_categories",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "id",
                table: "product_categories",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_at",
                table: "product_categories",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "created_at",
                table: "product_categories");

            migrationBuilder.DropColumn(
                name: "id",
                table: "product_categories");

            migrationBuilder.DropColumn(
                name: "updated_at",
                table: "product_categories");
        }
    }
}
