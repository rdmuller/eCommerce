using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eCommerce.Infra.Migrations
{
    /// <inheritdoc />
    public partial class addUserFather : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FatherName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FatherName",
                table: "Users");
        }
    }
}
