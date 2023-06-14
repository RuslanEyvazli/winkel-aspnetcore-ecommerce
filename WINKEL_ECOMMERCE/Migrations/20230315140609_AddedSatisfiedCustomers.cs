using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WINKEL_ECOMMERCE.Migrations
{
    /// <inheritdoc />
    public partial class AddedSatisfiedCustomers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SatisfiedCustomers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    AltImage = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Position = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SatisfiedCustomers", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "SatisfiedCustomers",
                columns: new[] { "Id", "AltImage", "Content", "Icon", "Image", "Name", "Position" },
                values: new object[,]
                {
                    { 1, "Garreth Smith", "Far far away, behind the word mountains, far from the countries Vokalia and Consonantia, there  live the blind texts.", "fas fa-quote-left", "person_1.webp", "Garreth Smith", "MARKETING  MANAGER" },
                    { 2, "Garreth Smith", "Far far away, behind the word mountains, far from the countries Vokalia and Consonantia, there  live the blind texts.", "fas fa-quote-left", "person_2.webp", "Wiktoria Manilla", "SALES  MANAGER" },
                    { 3, "Garreth Smith", "Far far away, behind the word mountains, far from the countries Vokalia and Consonantia, there  live the blind texts.", "fas fa-quote-right", "person_3.webp", "Wladyslaw Szpilman", "CONTENT MANAGER" },
                    { 4, "Garreth Smith", "Far far away, behind the word mountains, far from the countries Vokalia and Consonantia, there  live the blind texts.", "fas fa-quote-left", "person_1.webp", "Garreth Smith", "MARKETING  MANAGER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SatisfiedCustomers");
        }
    }
}
