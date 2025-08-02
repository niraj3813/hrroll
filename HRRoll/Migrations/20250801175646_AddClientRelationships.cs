using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRRoll.Migrations
{
    /// <inheritdoc />
    public partial class AddClientRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_ClientMasters_ClientMasterId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_ClientMasters_ClientMasterId",
                table: "Employees");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_ClientMasters_ClientMasterId",
                table: "AspNetUsers",
                column: "ClientMasterId",
                principalTable: "ClientMasters",
                principalColumn: "ClientMasterId",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_ClientMasters_ClientMasterId",
                table: "Employees",
                column: "ClientMasterId",
                principalTable: "ClientMasters",
                principalColumn: "ClientMasterId",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_ClientMasters_ClientMasterId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_ClientMasters_ClientMasterId",
                table: "Employees");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_ClientMasters_ClientMasterId",
                table: "AspNetUsers",
                column: "ClientMasterId",
                principalTable: "ClientMasters",
                principalColumn: "ClientMasterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_ClientMasters_ClientMasterId",
                table: "Employees",
                column: "ClientMasterId",
                principalTable: "ClientMasters",
                principalColumn: "ClientMasterId");
        }
    }
}
