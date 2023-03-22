using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CRUD_app.Migrations
{
    /// <inheritdoc />
    public partial class AddCommonProviders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Providers",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 2, "Leroy Merlin" },
                    { 3, "Норникель" },
                    { 4, "Роснефть" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Providers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Providers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Providers",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
