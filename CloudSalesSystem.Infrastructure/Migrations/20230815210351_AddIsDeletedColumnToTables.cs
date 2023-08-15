using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CloudSalesSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddIsDeletedColumnToTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "is_deleted",
                table: "subscriptions",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "is_deleted",
                table: "subscription_items",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "is_deleted",
                table: "licenses",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "is_deleted",
                table: "customers",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "is_deleted",
                table: "accounts",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "is_deleted",
                table: "subscriptions");

            migrationBuilder.DropColumn(
                name: "is_deleted",
                table: "subscription_items");

            migrationBuilder.DropColumn(
                name: "is_deleted",
                table: "licenses");

            migrationBuilder.DropColumn(
                name: "is_deleted",
                table: "customers");

            migrationBuilder.DropColumn(
                name: "is_deleted",
                table: "accounts");
        }
    }
}
