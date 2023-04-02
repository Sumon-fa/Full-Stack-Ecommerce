using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    public partial class AddRoleMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "id", "concurrency_stamp", "name", "normalized_name" },
                values: new object[,]
                {
                    { 1, "df6dc5b5-69c6-46be-8a81-0b5b813ed6c0", "User", "USER" },
                    { 2, "a3f6db3c-a3c0-462d-a532-5de43b49b703", "Admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "ix_orders_customer",
                table: "orders",
                column: "customer");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_orders_customer",
                table: "orders");

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "id",
                keyValue: 2);
        }
    }
}
