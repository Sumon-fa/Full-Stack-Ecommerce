using System;
using Microsoft.EntityFrameworkCore.Migrations;
using backend.Models;

#nullable disable

namespace backend.Migrations
{
    public partial class AddOrderMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:order_status", "pending,shipped,delivered");

            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    customer = table.Column<string>(type: "text", nullable: false),
                    status = table.Column<Order.OrderStatus>(type: "order_status", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_orders", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "cart_items",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    product_id = table.Column<Guid>(type: "uuid", nullable: false),
                    updated_price = table.Column<double>(type: "double precision", nullable: false),
                    amount = table.Column<int>(type: "integer", nullable: false),
                    order_id = table.Column<Guid>(type: "uuid", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cart_items", x => x.id);
                    table.ForeignKey(
                        name: "fk_cart_items_orders_order_id",
                        column: x => x.order_id,
                        principalTable: "orders",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_cart_items_products_product_id",
                        column: x => x.product_id,
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_cart_items_order_id",
                table: "cart_items",
                column: "order_id");

            migrationBuilder.CreateIndex(
                name: "ix_cart_items_product_id",
                table: "cart_items",
                column: "product_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cart_items");

            migrationBuilder.DropTable(
                name: "orders");

            migrationBuilder.AlterDatabase()
                .OldAnnotation("Npgsql:Enum:order_status", "pending,shipped,delivered");
        }
    }
}
