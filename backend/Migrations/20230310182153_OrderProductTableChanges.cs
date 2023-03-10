using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Luxelane.Migrations
{
    /// <inheritdoc />
    public partial class OrderProductTableChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "pk_order_products",
                table: "order_products");

            migrationBuilder.AddColumn<int>(
                name: "order_product_id",
                table: "order_products",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddUniqueConstraint(
                name: "ak_order_products_order_id_product_id",
                table: "order_products",
                columns: new[] { "order_id", "product_id" });

            migrationBuilder.AddPrimaryKey(
                name: "pk_order_products",
                table: "order_products",
                column: "order_product_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "ak_order_products_order_id_product_id",
                table: "order_products");

            migrationBuilder.DropPrimaryKey(
                name: "pk_order_products",
                table: "order_products");

            migrationBuilder.DropColumn(
                name: "order_product_id",
                table: "order_products");

            migrationBuilder.AddPrimaryKey(
                name: "pk_order_products",
                table: "order_products",
                columns: new[] { "order_id", "product_id" });
        }
    }
}
