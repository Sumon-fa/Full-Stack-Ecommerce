using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    public partial class AddChangeOrderMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_cart_items_orders_order_id",
                table: "cart_items");

            migrationBuilder.AlterColumn<Guid>(
                name: "order_id",
                table: "cart_items",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 1,
                column: "concurrency_stamp",
                value: "cb67100b-6c30-43e7-bd5a-fa17573d58b2");

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 2,
                column: "concurrency_stamp",
                value: "43221e17-cdba-4be6-bb04-1014a2ba08bf");

            migrationBuilder.CreateIndex(
                name: "ix_users_email",
                table: "users",
                column: "email",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "fk_cart_items_orders_order_id",
                table: "cart_items",
                column: "order_id",
                principalTable: "orders",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_cart_items_orders_order_id",
                table: "cart_items");

            migrationBuilder.DropIndex(
                name: "ix_users_email",
                table: "users");

            migrationBuilder.AlterColumn<Guid>(
                name: "order_id",
                table: "cart_items",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 1,
                column: "concurrency_stamp",
                value: "df6dc5b5-69c6-46be-8a81-0b5b813ed6c0");

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 2,
                column: "concurrency_stamp",
                value: "a3f6db3c-a3c0-462d-a532-5de43b49b703");

            migrationBuilder.AddForeignKey(
                name: "fk_cart_items_orders_order_id",
                table: "cart_items",
                column: "order_id",
                principalTable: "orders",
                principalColumn: "id");
        }
    }
}
