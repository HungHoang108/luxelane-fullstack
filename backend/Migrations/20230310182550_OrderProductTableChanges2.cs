using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Luxelane.Migrations
{
    /// <inheritdoc />
    public partial class OrderProductTableChanges2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "order_product_id",
                table: "order_products");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "order_product_id",
                table: "order_products",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
