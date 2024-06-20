using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Koton.Entities.Migrations
{
    /// <inheritdoc />
    public partial class deleteUsernamefromCustomer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerUsername",
                table: "Customers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CustomerUsername",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
