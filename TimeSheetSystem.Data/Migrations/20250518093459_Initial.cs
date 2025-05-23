using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TimeSheetSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "TimeSheetSystem");

            migrationBuilder.CreateTable(
                name: "Employee",
                schema: "TimeSheetSystem",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstName = table.Column<string>(type: "character varying", nullable: false),
                    LastName = table.Column<string>(type: "character varying", nullable: false),
                    Email = table.Column<string>(type: "character varying", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Employee_pkey", x => x.Id);
                    table.ForeignKey(
                        name: "Employee_CreatedBy_fkey",
                        column: x => x.CreatedBy,
                        principalSchema: "TimeSheetSystem",
                        principalTable: "Employee",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "Employee_DeletedBy_fkey",
                        column: x => x.DeletedBy,
                        principalSchema: "TimeSheetSystem",
                        principalTable: "Employee",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "Employee_UpdatedBy_fkey",
                        column: x => x.UpdatedBy,
                        principalSchema: "TimeSheetSystem",
                        principalTable: "Employee",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Role",
                schema: "TimeSheetSystem",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Role_pkey", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Project",
                schema: "TimeSheetSystem",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Manager = table.Column<Guid>(type: "uuid", nullable: false),
                    MaxEmployees = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Project_pkey", x => x.Id);
                    table.ForeignKey(
                        name: "Project_CreatedBy_fkey",
                        column: x => x.CreatedBy,
                        principalSchema: "TimeSheetSystem",
                        principalTable: "Employee",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "Project_DeletedBy_fkey",
                        column: x => x.DeletedBy,
                        principalSchema: "TimeSheetSystem",
                        principalTable: "Employee",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "Project_Manager_fkey",
                        column: x => x.Manager,
                        principalSchema: "TimeSheetSystem",
                        principalTable: "Employee",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "Project_UpdatedBy_fkey",
                        column: x => x.UpdatedBy,
                        principalSchema: "TimeSheetSystem",
                        principalTable: "Employee",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EmployeeRole",
                schema: "TimeSheetSystem",
                columns: table => new
                {
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("EmployeeRole_pkey", x => new { x.RoleId, x.EmployeeId });
                    table.ForeignKey(
                        name: "EmployeeRole_EmployeeId_fkey",
                        column: x => x.EmployeeId,
                        principalSchema: "TimeSheetSystem",
                        principalTable: "Employee",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "EmployeeRole_RoleId_fkey",
                        column: x => x.RoleId,
                        principalSchema: "TimeSheetSystem",
                        principalTable: "Role",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EmployeeProject",
                schema: "TimeSheetSystem",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uuid", nullable: false),
                    Role = table.Column<string>(type: "character varying", nullable: false),
                    AssignedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    JoinedDate = table.Column<DateOnly>(type: "date", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("EmployeeProject_pkey", x => x.Id);
                    table.ForeignKey(
                        name: "EmployeeProject_AssignedBy_fkey",
                        column: x => x.AssignedBy,
                        principalSchema: "TimeSheetSystem",
                        principalTable: "Employee",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "EmployeeProject_CreatedBy_fkey",
                        column: x => x.CreatedBy,
                        principalSchema: "TimeSheetSystem",
                        principalTable: "Employee",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "EmployeeProject_DeletedBy_fkey",
                        column: x => x.DeletedBy,
                        principalSchema: "TimeSheetSystem",
                        principalTable: "Employee",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "EmployeeProject_EmployeeId_fkey",
                        column: x => x.EmployeeId,
                        principalSchema: "TimeSheetSystem",
                        principalTable: "Employee",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "EmployeeProject_ProjectId_fkey",
                        column: x => x.ProjectId,
                        principalSchema: "TimeSheetSystem",
                        principalTable: "Project",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "EmployeeProject_UpdatedBy_fkey",
                        column: x => x.UpdatedBy,
                        principalSchema: "TimeSheetSystem",
                        principalTable: "Employee",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TimeLog",
                schema: "TimeSheetSystem",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uuid", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    Hours = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: false),
                    ApprovedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    Note = table.Column<string>(type: "text", nullable: true),
                    IsApproved = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("TimeLog_pkey", x => x.Id);
                    table.ForeignKey(
                        name: "TimeLog_ApprovedBy_fkey",
                        column: x => x.ApprovedBy,
                        principalSchema: "TimeSheetSystem",
                        principalTable: "Employee",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "TimeLog_CreatedBy_fkey",
                        column: x => x.CreatedBy,
                        principalSchema: "TimeSheetSystem",
                        principalTable: "Employee",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "TimeLog_DeletedBy_fkey",
                        column: x => x.DeletedBy,
                        principalSchema: "TimeSheetSystem",
                        principalTable: "Employee",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "TimeLog_EmployeeId_fkey",
                        column: x => x.EmployeeId,
                        principalSchema: "TimeSheetSystem",
                        principalTable: "Employee",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "TimeLog_ProjectId_fkey",
                        column: x => x.ProjectId,
                        principalSchema: "TimeSheetSystem",
                        principalTable: "Project",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "TimeLog_UpdatedBy_fkey",
                        column: x => x.UpdatedBy,
                        principalSchema: "TimeSheetSystem",
                        principalTable: "Employee",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "Employee_Email_key",
                schema: "TimeSheetSystem",
                table: "Employee",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employee_CreatedBy",
                schema: "TimeSheetSystem",
                table: "Employee",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_DeletedBy",
                schema: "TimeSheetSystem",
                table: "Employee",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_UpdatedBy",
                schema: "TimeSheetSystem",
                table: "Employee",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeProject_AssignedBy",
                schema: "TimeSheetSystem",
                table: "EmployeeProject",
                column: "AssignedBy");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeProject_CreatedBy",
                schema: "TimeSheetSystem",
                table: "EmployeeProject",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeProject_DeletedBy",
                schema: "TimeSheetSystem",
                table: "EmployeeProject",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeProject_EmployeeId",
                schema: "TimeSheetSystem",
                table: "EmployeeProject",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeProject_ProjectId",
                schema: "TimeSheetSystem",
                table: "EmployeeProject",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeProject_UpdatedBy",
                schema: "TimeSheetSystem",
                table: "EmployeeProject",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeRole_EmployeeId",
                schema: "TimeSheetSystem",
                table: "EmployeeRole",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_CreatedBy",
                schema: "TimeSheetSystem",
                table: "Project",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Project_DeletedBy",
                schema: "TimeSheetSystem",
                table: "Project",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Project_Manager",
                schema: "TimeSheetSystem",
                table: "Project",
                column: "Manager");

            migrationBuilder.CreateIndex(
                name: "IX_Project_UpdatedBy",
                schema: "TimeSheetSystem",
                table: "Project",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "Role_Name_key",
                schema: "TimeSheetSystem",
                table: "Role",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TimeLog_ApprovedBy",
                schema: "TimeSheetSystem",
                table: "TimeLog",
                column: "ApprovedBy");

            migrationBuilder.CreateIndex(
                name: "IX_TimeLog_CreatedBy",
                schema: "TimeSheetSystem",
                table: "TimeLog",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_TimeLog_DeletedBy",
                schema: "TimeSheetSystem",
                table: "TimeLog",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_TimeLog_EmployeeId",
                schema: "TimeSheetSystem",
                table: "TimeLog",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeLog_ProjectId",
                schema: "TimeSheetSystem",
                table: "TimeLog",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeLog_UpdatedBy",
                schema: "TimeSheetSystem",
                table: "TimeLog",
                column: "UpdatedBy");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeProject",
                schema: "TimeSheetSystem");

            migrationBuilder.DropTable(
                name: "EmployeeRole",
                schema: "TimeSheetSystem");

            migrationBuilder.DropTable(
                name: "TimeLog",
                schema: "TimeSheetSystem");

            migrationBuilder.DropTable(
                name: "Role",
                schema: "TimeSheetSystem");

            migrationBuilder.DropTable(
                name: "Project",
                schema: "TimeSheetSystem");

            migrationBuilder.DropTable(
                name: "Employee",
                schema: "TimeSheetSystem");
        }
    }
}
