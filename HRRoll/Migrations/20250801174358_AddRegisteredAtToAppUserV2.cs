using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRRoll.Migrations
{
    /// <inheritdoc />
    public partial class AddRegisteredAtToAppUserV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ParentClientCode",
                table: "ClientMasters");

            migrationBuilder.AddColumn<string>(
                name: "ClientCode",
                table: "ClientMasters",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MasterCode",
                table: "ClientMasters",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ClientMasterId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ClientMasterId",
                table: "AspNetUsers",
                column: "ClientMasterId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_ClientMasters_ClientMasterId",
                table: "AspNetUsers",
                column: "ClientMasterId",
                principalTable: "ClientMasters",
                principalColumn: "ClientMasterId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_ClientMasters_ClientMasterId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ClientMasterId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ClientCode",
                table: "ClientMasters");

            migrationBuilder.DropColumn(
                name: "MasterCode",
                table: "ClientMasters");

            migrationBuilder.DropColumn(
                name: "ClientMasterId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "ParentClientCode",
                table: "ClientMasters",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
