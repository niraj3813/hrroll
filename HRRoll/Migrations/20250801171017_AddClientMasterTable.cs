using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRRoll.Migrations
{
    /// <inheritdoc />
    public partial class AddClientMasterTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClientMasterId",
                table: "Employees",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ClientMasterId",
                table: "Employees",
                column: "ClientMasterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Clients_ClientMasterId",
                table: "Employees",
                column: "ClientMasterId",
                principalTable: "Clients",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Clients_ClientMasterId",
                table: "Employees");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_Employees_ClientMasterId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "ClientMasterId",
                table: "Employees");
        }
    }
}
