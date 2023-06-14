using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WINKEL_ECOMMERCE.Migrations
{
    /// <inheritdoc />
    public partial class AddedCreatedAttoProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Products",
                type: "smalldatetime",
                nullable: false,
                defaultValueSql: "SYSDATETIME()");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Products");
        }
    }
}
