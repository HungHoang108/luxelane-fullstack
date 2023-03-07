using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Luxelane.Migrations
{
    /// <inheritdoc />
    public partial class FixUserandAddressFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_addresses_users_user_id",
                table: "addresses");

            migrationBuilder.DropForeignKey(
                name: "fk_addresses_users_user_id1",
                table: "addresses");

            migrationBuilder.DropIndex(
                name: "ix_addresses_user_id",
                table: "addresses");

            migrationBuilder.DropIndex(
                name: "ix_addresses_user_id1",
                table: "addresses");

            migrationBuilder.DropColumn(
                name: "user_id1",
                table: "addresses");

            migrationBuilder.CreateIndex(
                name: "ix_addresses_user_id",
                table: "addresses",
                column: "user_id");

            migrationBuilder.AddForeignKey(
                name: "fk_addresses_users_user_id",
                table: "addresses",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_addresses_users_user_id",
                table: "addresses");

            migrationBuilder.DropIndex(
                name: "ix_addresses_user_id",
                table: "addresses");

            migrationBuilder.AddColumn<int>(
                name: "user_id1",
                table: "addresses",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "ix_addresses_user_id",
                table: "addresses",
                column: "user_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_addresses_user_id1",
                table: "addresses",
                column: "user_id1");

            migrationBuilder.AddForeignKey(
                name: "fk_addresses_users_user_id",
                table: "addresses",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "fk_addresses_users_user_id1",
                table: "addresses",
                column: "user_id1",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
