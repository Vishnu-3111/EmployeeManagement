using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Employee.Migrations
{
    /// <inheritdoc />
    public partial class EmployeeManagement : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmployeeManagement",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Designation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pincode = table.Column<int>(type: "int", nullable: false),
                    ManagerID = table.Column<int>(type: "int", nullable: false),
                    Salary = table.Column<int>(type: "int", nullable: false),
                    DepartmentName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeManagement", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "educationalqualification",
                columns: table => new
                {
                    degree = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    percentage = table.Column<int>(type: "int", nullable: false),
                    EmployeesEmpId = table.Column<int>(type: "int", nullable: false),
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

            migrationBuilder.DropTable(
                name: "EmployeeManagement");
        }
    }
}
