using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WINKEL_ECOMMERCE.Migrations
{
    /// <inheritdoc />
    public partial class AddedSlihAndShipItemDataUsingFluentAPIOnModelCreating : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShipItems_Ships_ShipId",
                table: "ShipItems");

            migrationBuilder.AlterColumn<int>(
                name: "ShipId",
                table: "ShipItems",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Ships",
                columns: new[] { "Id", "AltImage", "Description", "Header", "Image", "Link" },
                values: new object[] { 1, "This is a photo", "But nothing the copy said could convince her and so it didn’t take long until a few insidious Copy Writers ambushed her, made her drunk with Longe and Parole and dragged her into their agency, where they abused her for their.", "Better Way to Ship Your Products", "about.webp", "https://vimeo.com/45830194" });

            migrationBuilder.InsertData(
                table: "ShipItems",
                columns: new[] { "Id", "Content", "Icon", "ShipId", "Title" },
                values: new object[,]
                {
                    { 1, "Even the all-powerful Pointing has no control about the blind texts it is an almost unorthographic", "fas fa-tablet-alt", 1, "REFUND POLICY" },
                    { 2, "Even the all-powerful Pointing has no control about the blind texts it is an almost unorthographic", "fas fa-tablet-alt", 1, "REFUND POLICY" },
                    { 3, "Even the all-powerful Pointing has no control about the blind texts it is an almost unorthographic", "fas fa-tablet-alt", 1, "REFUND POLICY" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ShipItems_Ships_ShipId",
                table: "ShipItems",
                column: "ShipId",
                principalTable: "Ships",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShipItems_Ships_ShipId",
                table: "ShipItems");

            migrationBuilder.DeleteData(
                table: "ShipItems",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ShipItems",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ShipItems",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Ships",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AlterColumn<int>(
                name: "ShipId",
                table: "ShipItems",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_ShipItems_Ships_ShipId",
                table: "ShipItems",
                column: "ShipId",
                principalTable: "Ships",
                principalColumn: "Id");
        }
    }
}
