using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CloudSalesSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveProductsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_subscription_items_products_product_id",
                table: "subscription_items");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropIndex(
                name: "ix_subscription_items_product_id",
                table: "subscription_items");

            migrationBuilder.AddColumn<string>(
                name: "product_name",
                table: "subscription_items",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "product_name",
                table: "subscription_items");

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    name = table.Column<string>(type: "text", nullable: false),
                    provider = table.Column<string>(type: "text", nullable: false),
                    updated_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_products", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "ix_subscription_items_product_id",
                table: "subscription_items",
                column: "product_id");

            migrationBuilder.AddForeignKey(
                name: "fk_subscription_items_products_product_id",
                table: "subscription_items",
                column: "product_id",
                principalTable: "products",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
