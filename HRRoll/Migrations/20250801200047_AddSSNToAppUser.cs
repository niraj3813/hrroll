using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRRoll.Migrations
{
    /// <inheritdoc />
    public partial class AddSSNToAppUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SSN",
                table: "AspNetUsers",
                type: "nvarchar(9)",
                maxLength: 9,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SSN",
                table: "AspNetUsers");
        }
    }
}
