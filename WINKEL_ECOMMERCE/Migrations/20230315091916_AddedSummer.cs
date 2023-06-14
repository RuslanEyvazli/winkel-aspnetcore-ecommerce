using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WINKEL_ECOMMERCE.Migrations
{
    /// <inheritdoc />
    public partial class AddedSummer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Summers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LeftImage = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    LeftHeading = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    LeftContent = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    RightImage = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    RightHeading = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    RightContent = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Summers", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Summers",
                columns: new[] { "Id", "LeftContent", "LeftHeading", "LeftImage", "RightContent", "RightHeading", "RightImage" },
                values: new object[] { 1, "Far far away, behind the word mountains, far from the countries Vokalia and Consonantia, there live the blind texts. Separated they live in Bookmarksgrove right at the coast of the Semantics, a large language ocean.", "NEW MEN'S CLOTHING SUMMER COLLECTION 2019", "about-2.webp", " NEW WOMEN'S CLOTHING SUMMER COLLECTION 2019\r\n                Far far away, behind the word mountains, far from the countries Vokalia and Consonantia, there live the blind texts. Separated they live in Bookmarksgrove right at the coast of the Semantics, a large language ocean.", "NEW WOMEN'S CLOTHING SUMMER COLLECTION 2019", "about-1.jpg" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Summers");
        }
    }
}
