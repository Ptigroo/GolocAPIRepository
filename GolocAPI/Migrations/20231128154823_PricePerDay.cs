using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GolocAPI.Migrations
{
    /// <inheritdoc />
    public partial class PricePerDay : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            /*migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2923f6a8-6343-4772-a6ad-b68bc096e20a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "480493dd-f946-4a0f-99e3-ab5d416fd934");
            */
            migrationBuilder.AddColumn<double>(
                name: "PricePerDay",
                table: "Product",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
            /*
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "559053ea-e7ff-4f15-883a-1eb1808f1813", null, "Member", "MEMBER" },
                    { "f4786709-8cbb-4722-ae71-1989b8324333", null, "Admin", "ADMIN" }
                });*/
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "559053ea-e7ff-4f15-883a-1eb1808f1813");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f4786709-8cbb-4722-ae71-1989b8324333");

            migrationBuilder.DropColumn(
                name: "PricePerDay",
                table: "Product");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2923f6a8-6343-4772-a6ad-b68bc096e20a", null, "Admin", "ADMIN" },
                    { "480493dd-f946-4a0f-99e3-ab5d416fd934", null, "Member", "MEMBER" }
                });
        }
    }
}
