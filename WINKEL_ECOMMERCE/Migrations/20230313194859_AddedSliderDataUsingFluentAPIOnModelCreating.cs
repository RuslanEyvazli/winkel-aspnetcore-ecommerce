using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WINKEL_ECOMMERCE.Migrations
{
    /// <inheritdoc />
    public partial class AddedSliderDataUsingFluentAPIOnModelCreating : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Sliders",
                columns: new[] { "Id", "AltImage", "Description", "Header", "Image", "LeftVerticalText", "SupHeader" },
                values: new object[,]
                {
                    { 1, "This is girl photo", "A small river named Duden flows by tehir place and supplies it with the necessary regelialia. It is a paradisematic country.", "A Thouroughly <b>Modern</b> Woman", "bg_2.webp", "BEST ECOMMECE ONLINE SHOP", "WINKEL ECOMMERCE SHOP" },
                    { 2, "This is boy photo", "A small river named Duden flows by tehir place and supplies it with the necessary regelialia. It is a paradisematic country.", "Catch Your Own\r\n    <pre><b>Stylish & Look</b></pre>", "bg_1.webp", "WINKEL ECOMMERCE SHOP", "ESTABLISHED SICNE 2000" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Sliders",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Sliders",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
