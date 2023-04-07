using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    public partial class AddRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "user_id",
                table: "roles",
                type: "integer",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 1,
                column: "concurrency_stamp",
                value: "d1c7d976-39a6-488b-90f5-a824015de8ac");

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 2,
                column: "concurrency_stamp",
                value: "e000727f-885d-4f11-b796-bb34311de19a");

            migrationBuilder.CreateIndex(
                name: "ix_roles_user_id",
                table: "roles",
                column: "user_id");

            migrationBuilder.AddForeignKey(
                name: "fk_roles_users_user_id",
                table: "roles",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_roles_users_user_id",
                table: "roles");

            migrationBuilder.DropIndex(
                name: "ix_roles_user_id",
                table: "roles");

            migrationBuilder.DropColumn(
                name: "user_id",
                table: "roles");

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
        }
    }
}
