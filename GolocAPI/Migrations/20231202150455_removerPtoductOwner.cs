using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GolocAPI.Migrations
{
    /// <inheritdoc />
    public partial class removerPtoductOwner : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "OwnerId1",
                table: "Products",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_OwnerId1",
                table: "Products",
                newName: "IX_Products_UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_AspNetUsers_UserId",
                table: "Products");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "672e1f8f-5270-4988-bf70-7e49208d9001");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e91e95a1-73a5-4e2d-980c-9376878be3ee");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Products",
                newName: "OwnerId1");

            migrationBuilder.RenameIndex(
                name: "IX_Products_UserId",
                table: "Products",
                newName: "IX_Products_OwnerId1");

            migrationBuilder.AddColumn<int>(
                name: "OwnerId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "30fa01ea-93e3-4b61-9ae6-233e7f99e21c", null, "Member", "MEMBER" },
                    { "e7d80eee-2af0-4829-905d-3b981c2da465", null, "Admin", "ADMIN" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Products_AspNetUsers_OwnerId1",
                table: "Products",
                column: "OwnerId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
