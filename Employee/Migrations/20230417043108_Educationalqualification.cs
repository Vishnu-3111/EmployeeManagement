using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Employee.Migrations
{
    /// <inheritdoc />
    public partial class Educationalqualification : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "educationalqualification",
                columns: table => new
                {
                    degree = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    percentage = table.Column<int>(type: "int", nullable: false),
                    EmployeeManagementEmployeeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_educationalqualification", x => x.degree);
                    table.ForeignKey(
                        name: "FK_educationalqualification_EmployeeManagement_EmployeeManagementEmployeeId",
                        column: x => x.EmployeeManagementEmployeeId,
                        principalTable: "EmployeeManagement",
                        principalColumn: "EmployeeId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_educationalqualification_EmployeeManagementEmployeeId",
                table: "educationalqualification",
                column: "EmployeeManagementEmployeeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "educationalqualification");
        }
    }
}
