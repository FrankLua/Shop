using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DarkStore.Migrations
{
    /// <inheritdoc />
    public partial class _54 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.InsertData(
                
                table: "Country",
                columns: new[] { "Code", "Name" },
                values: new object[,]
                {
                    { "AME", "Америка" },
                    { "CHI", "Китай" },
                    { "EFI", "Эфиопия" },
                    { "EUR", "Европа" },
                    { "JAP", "Япония" },
                    { "RUS", "Россия" }
                });


        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductCountry_CountryId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductCountry",
                table: "ProductCountry");

            migrationBuilder.DeleteData(
                table: "ProductCountry",
                keyColumn: "Code",
                keyValue: "AME");

            migrationBuilder.DeleteData(
                table: "ProductCountry",
                keyColumn: "Code",
                keyValue: "CHI");

            migrationBuilder.DeleteData(
                table: "ProductCountry",
                keyColumn: "Code",
                keyValue: "EFI");

            migrationBuilder.DeleteData(
                table: "ProductCountry",
                keyColumn: "Code",
                keyValue: "EUR");

            migrationBuilder.DeleteData(
                table: "ProductCountry",
                keyColumn: "Code",
                keyValue: "JAP");

            migrationBuilder.DeleteData(
                table: "ProductCountry",
                keyColumn: "Code",
                keyValue: "RUS");

            migrationBuilder.RenameTable(
                name: "ProductCountry",
                newName: "Country");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Products",
                newName: "title");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Country",
                table: "Country",
                column: "Code");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Country_CountryId",
                table: "Products",
                column: "CountryId",
                principalTable: "Country",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
