using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Koton.Entities.Migrations
{
    /// <inheritdoc />
    public partial class addedgender : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerGender",
                table: "Customers");

            migrationBuilder.AddColumn<int>(
                name: "Gender",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Customers");

            migrationBuilder.AddColumn<string>(
                name: "CustomerGender",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
