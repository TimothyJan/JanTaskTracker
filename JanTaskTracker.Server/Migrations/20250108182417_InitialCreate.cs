using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace JanTaskTracker.Server.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DepartmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DepartmentID);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.ProjectId);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DepartmentID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleID);
                    table.ForeignKey(
                        name: "FK_Roles_Departments_DepartmentID",
                        column: x => x.DepartmentID,
                        principalTable: "Departments",
                        principalColumn: "DepartmentID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DepartmentID = table.Column<int>(type: "int", nullable: false),
                    RoleID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeID);
                    table.ForeignKey(
                        name: "FK_Employees_Departments_DepartmentID",
                        column: x => x.DepartmentID,
                        principalTable: "Departments",
                        principalColumn: "DepartmentID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employees_Roles_RoleID",
                        column: x => x.RoleID,
                        principalTable: "Roles",
                        principalColumn: "RoleID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProjectTasks",
                columns: table => new
                {
                    ProjectTaskId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AssignedEmployeeId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectTasks", x => x.ProjectTaskId);
                    table.ForeignKey(
                        name: "FK_ProjectTasks_Employees_AssignedEmployeeId",
                        column: x => x.AssignedEmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DepartmentID", "DepartmentName" },
                values: new object[,]
                {
                    { 1, "Finance" },
                    { 2, "Human Resources" },
                    { 3, "Information Technology" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "ProjectId", "Description", "DueDate", "ProjectName", "StartDate", "Status" },
                values: new object[,]
                {
                    { 1, "First project", new DateTime(2025, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Project Alpha", new DateTime(2024, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Active" },
                    { 2, "Second project", new DateTime(2025, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Project Beta", new DateTime(2024, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Active" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleID", "DepartmentID", "RoleName" },
                values: new object[,]
                {
                    { 1, 1, "Accountant" },
                    { 2, 1, "Financial Analyst" },
                    { 3, 1, "Finance Manager" },
                    { 4, 2, "HR Assistant" },
                    { 5, 2, "HR Specialist" },
                    { 6, 2, "HR Director" },
                    { 7, 3, "Software Engineer" },
                    { 8, 3, "Front-End Developer" },
                    { 9, 3, "Back-End Developer" },
                    { 10, 3, "Full-Stack Developer" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeID", "DepartmentID", "Name", "RoleID", "Salary" },
                values: new object[,]
                {
                    { 1, 1, "Bob Smith", 2, 70000m },
                    { 2, 2, "Catherine Green", 5, 65000m },
                    { 3, 3, "David Brown", 7, 90000m }
                });

            migrationBuilder.InsertData(
                table: "ProjectTasks",
                columns: new[] { "ProjectTaskId", "AssignedEmployeeId", "Description", "DueDate", "ProjectId", "StartDate", "Status", "Title" },
                values: new object[,]
                {
                    { 1, 3, "Task for Project Alpha", new DateTime(2024, 12, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2024, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Completed", "Task 1" },
                    { 2, 3, "Another Task for Project Alpha", new DateTime(2025, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2024, 12, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Active", "Task 2" },
                    { 3, 2, "Task for Project Beta", new DateTime(2025, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2025, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Completed", "Task 3" },
                    { 4, 2, "Another Task for Project Beta", new DateTime(2025, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2024, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Active", "Task 4" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmentID",
                table: "Employees",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_RoleID",
                table: "Employees",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTasks_AssignedEmployeeId",
                table: "ProjectTasks",
                column: "AssignedEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_DepartmentID",
                table: "Roles",
                column: "DepartmentID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "ProjectTasks");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
