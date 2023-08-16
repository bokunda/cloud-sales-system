using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CloudSalesSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "customers",
                columns: new[] { "id", "created_on", "description", "is_deleted", "name", "updated_on" },
                values: new object[] { new Guid("697eefc8-cb19-41b0-8302-e91fca1805bf"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Customer_Description_1", false, "Customer_Name_1", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.InsertData(
                table: "subscriptions",
                columns: new[] { "id", "created_on", "description", "is_deleted", "name", "updated_on" },
                values: new object[] { new Guid("74e083d4-13ae-4afc-8040-62d226357c56"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Subscription_Description_1", false, "Subscription_Name_1", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "created_on", "customer_id", "description", "is_deleted", "name", "updated_on" },
                values: new object[,]
                {
                    { new Guid("e0000b5b-7ad0-4b27-8457-47262fdcf1c7"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("697eefc8-cb19-41b0-8302-e91fca1805bf"), "Account_Description_1", false, "Account_Name_1", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("e1000b5b-7ad0-4b27-8457-47262fdcf1c7"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("697eefc8-cb19-41b0-8302-e91fca1805bf"), "Account_Description_2", false, "Account_Name_2", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("e2000b5b-7ad0-4b27-8457-47262fdcf1c7"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("697eefc8-cb19-41b0-8302-e91fca1805bf"), "Account_Description_3", false, "Account_Name_3", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "customer_subscriptions",
                columns: new[] { "customer_id", "subscription_id" },
                values: new object[] { new Guid("697eefc8-cb19-41b0-8302-e91fca1805bf"), new Guid("74e083d4-13ae-4afc-8040-62d226357c56") });

            migrationBuilder.InsertData(
                table: "subscription_items",
                columns: new[] { "id", "created_on", "is_deleted", "product_id", "product_name", "quantity", "state", "subscription_id", "updated_on", "valid_to_date" },
                values: new object[,]
                {
                    { new Guid("74e083d4-13ae-4afc-8040-62d226357c56"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, new Guid("e913c473-25a3-49aa-a80e-d62da922ca5e"), "Service_1", 7, 1, new Guid("74e083d4-13ae-4afc-8040-62d226357c56"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateOnly(2025, 1, 1) },
                    { new Guid("75e083d4-13ae-4afc-8040-62d226357c56"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, new Guid("ea13c473-25a3-49aa-a80e-d62da922ca5e"), "Service_2", 26, 1, new Guid("74e083d4-13ae-4afc-8040-62d226357c56"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateOnly(2025, 9, 1) },
                    { new Guid("76e083d4-13ae-4afc-8040-62d226357c56"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, new Guid("eb13c473-25a3-49aa-a80e-d62da922ca5e"), "Service_3", 19, 1, new Guid("74e083d4-13ae-4afc-8040-62d226357c56"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateOnly(2025, 5, 1) }
                });

            migrationBuilder.InsertData(
                table: "licenses",
                columns: new[] { "id", "account_id", "created_on", "is_deleted", "key", "subscription_item_id", "updated_on" },
                values: new object[,]
                {
                    { new Guid("43a13dd2-b95d-48ea-c763-08db9e382468"), new Guid("e1000b5b-7ad0-4b27-8457-47262fdcf1c7"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "D5694155-870D-41BF-BD38-01742D5CDD53", new Guid("74e083d4-13ae-4afc-8040-62d226357c56"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("446a397f-4d49-4d8c-b775-2ef6df1d9b61"), new Guid("e0000b5b-7ad0-4b27-8457-47262fdcf1c7"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "D3694155-870D-41BF-BD38-01742D5CDD53", new Guid("74e083d4-13ae-4afc-8040-62d226357c56"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("f7c7f5dc-47b6-40b7-c760-08db9e382468"), new Guid("e0000b5b-7ad0-4b27-8457-47262fdcf1c7"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, "D4694155-870D-41BF-BD38-01742D5CDD53", new Guid("74e083d4-13ae-4afc-8040-62d226357c56"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "accounts",
                keyColumn: "id",
                keyValue: new Guid("e2000b5b-7ad0-4b27-8457-47262fdcf1c7"));

            migrationBuilder.DeleteData(
                table: "customer_subscriptions",
                keyColumns: new[] { "customer_id", "subscription_id" },
                keyValues: new object[] { new Guid("697eefc8-cb19-41b0-8302-e91fca1805bf"), new Guid("74e083d4-13ae-4afc-8040-62d226357c56") });

            migrationBuilder.DeleteData(
                table: "licenses",
                keyColumn: "id",
                keyValue: new Guid("43a13dd2-b95d-48ea-c763-08db9e382468"));

            migrationBuilder.DeleteData(
                table: "licenses",
                keyColumn: "id",
                keyValue: new Guid("446a397f-4d49-4d8c-b775-2ef6df1d9b61"));

            migrationBuilder.DeleteData(
                table: "licenses",
                keyColumn: "id",
                keyValue: new Guid("f7c7f5dc-47b6-40b7-c760-08db9e382468"));

            migrationBuilder.DeleteData(
                table: "subscription_items",
                keyColumn: "id",
                keyValue: new Guid("75e083d4-13ae-4afc-8040-62d226357c56"));

            migrationBuilder.DeleteData(
                table: "subscription_items",
                keyColumn: "id",
                keyValue: new Guid("76e083d4-13ae-4afc-8040-62d226357c56"));

            migrationBuilder.DeleteData(
                table: "accounts",
                keyColumn: "id",
                keyValue: new Guid("e0000b5b-7ad0-4b27-8457-47262fdcf1c7"));

            migrationBuilder.DeleteData(
                table: "accounts",
                keyColumn: "id",
                keyValue: new Guid("e1000b5b-7ad0-4b27-8457-47262fdcf1c7"));

            migrationBuilder.DeleteData(
                table: "subscription_items",
                keyColumn: "id",
                keyValue: new Guid("74e083d4-13ae-4afc-8040-62d226357c56"));

            migrationBuilder.DeleteData(
                table: "customers",
                keyColumn: "id",
                keyValue: new Guid("697eefc8-cb19-41b0-8302-e91fca1805bf"));

            migrationBuilder.DeleteData(
                table: "subscriptions",
                keyColumn: "id",
                keyValue: new Guid("74e083d4-13ae-4afc-8040-62d226357c56"));
        }
    }
}
