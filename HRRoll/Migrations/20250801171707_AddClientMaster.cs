using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRRoll.Migrations
{
    /// <inheritdoc />
    public partial class AddClientMaster : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Clients_ClientMasterId",
                table: "Employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clients",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Clients");

            migrationBuilder.RenameTable(
                name: "Clients",
                newName: "ClientMasters");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ClientMasters",
                newName: "ClientMasterId");

            migrationBuilder.AddColumn<string>(
                name: "ClientName",
                table: "ClientMasters",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ParentClientCode",
                table: "ClientMasters",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClientMasters",
                table: "ClientMasters",
                column: "ClientMasterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_ClientMasters_ClientMasterId",
                table: "Employees",
                column: "ClientMasterId",
                principalTable: "ClientMasters",
                principalColumn: "ClientMasterId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_ClientMasters_ClientMasterId",
                table: "Employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClientMasters",
                table: "ClientMasters");

            migrationBuilder.DropColumn(
                name: "ClientName",
                table: "ClientMasters");

            migrationBuilder.DropColumn(
                name: "ParentClientCode",
                table: "ClientMasters");

            migrationBuilder.RenameTable(
                name: "ClientMasters",
                newName: "Clients");

            migrationBuilder.RenameColumn(
                name: "ClientMasterId",
                table: "Clients",
                newName: "Id");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Clients",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Clients",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clients",
                table: "Clients",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Clients_ClientMasterId",
                table: "Employees",
                column: "ClientMasterId",
                principalTable: "Clients",
                principalColumn: "Id");
        }
    }
}
