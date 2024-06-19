using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class addTestData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "PermissionName" },
                values: new object[,]
                {
                    { 1, "Read" },
                    { 2, "Write" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Description", "RoleName" },
                values: new object[,]
                {
                    { 1, "Administrator role with full permissions", "Admin" },
                    { 2, "Regular user role with limited permissions", "User" }
                });

            migrationBuilder.InsertData(
                table: "UserInfo",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1", 0, "9ae6fe15-15b8-4c5b-9e0c-6751b6c6d8f1", "john.doe@example.com", true, true, null, null, null, "AQAAAAEAACcQAAAAEBaKxU/EG+u0C5pW/VsH1jRZ0o1a+uzt4ToOeZ1dr6iST4lbk4Fomg==", "1234567890", false, "JBSY6Z5DZGPMZ5MN4NXQ4KOB4HCEAQ6Z", false, "john.doe" },
                    { "2", 0, "6ae6fe15-15b8-4c5b-9e0c-6751b6c6d8f1", "jane.doe@example.com", true, true, null, null, null, "AQAAAAEAACcQAAAAEJXrQbU/JB7Z4VLZMQ0pMflTeC1xB5DHzGxeL0O+flZ5g4rHkX5TRg==", "0987654321", false, "2SYI8S5DZGPMZ5MN4NXQ4KOB4HCEAQ6Z", false, "jane.doe" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "FullName", "OutOfOfficeBalance", "PeoplePartnerId", "Photo", "Position", "Status", "Subdivision", "UserInfoId" },
                values: new object[,]
                {
                    { 1, "John Doe", 10f, null, "photo_url_1", "Developer", "Active", "IT", "1" },
                    { 2, "Jane Doe", 8f, 1, "photo_url_2", "Manager", "Active", "HR", "2" }
                });

            migrationBuilder.InsertData(
                table: "LeaveRequests",
                columns: new[] { "Id", "AbsenceReason", "Comment", "EmployeeId", "EndDate", "StartDate", "Status" },
                values: new object[] { 1, "Vacation", "Annual vacation", 1, new DateTime(2024, 6, 29, 12, 17, 55, 399, DateTimeKind.Local).AddTicks(9084), new DateTime(2024, 6, 19, 12, 17, 55, 398, DateTimeKind.Local).AddTicks(806), "New" });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Comment", "EndDate", "ProjectManagerId", "ProjectType", "StartDate", "Status" },
                values: new object[] { 1, "Project A description", new DateTime(2024, 12, 19, 12, 17, 55, 400, DateTimeKind.Local).AddTicks(743), 1, "Internal", new DateTime(2024, 6, 19, 12, 17, 55, 400, DateTimeKind.Local).AddTicks(617), "Active" });

            migrationBuilder.InsertData(
                table: "ApprovalRequests",
                columns: new[] { "Id", "ApproverId", "Comment", "LeaveRequestId", "Status" },
                values: new object[] { 1, 2, "Enjoy your vacation!", 1, "Approved" });

            migrationBuilder.InsertData(
                table: "LeaveRequests",
                columns: new[] { "Id", "AbsenceReason", "Comment", "EmployeeId", "EndDate", "StartDate", "Status" },
                values: new object[] { 2, "Medical", "Medical leave", 2, new DateTime(2024, 6, 24, 12, 17, 55, 399, DateTimeKind.Local).AddTicks(9650), new DateTime(2024, 6, 19, 12, 17, 55, 399, DateTimeKind.Local).AddTicks(9644), "New" });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Comment", "EndDate", "ProjectManagerId", "ProjectType", "StartDate", "Status" },
                values: new object[] { 2, "Project B description", new DateTime(2024, 9, 19, 12, 17, 55, 400, DateTimeKind.Local).AddTicks(1327), 2, "External", new DateTime(2024, 6, 19, 12, 17, 55, 400, DateTimeKind.Local).AddTicks(1323), "Active" });

            migrationBuilder.InsertData(
                table: "ApprovalRequests",
                columns: new[] { "Id", "ApproverId", "Comment", "LeaveRequestId", "Status" },
                values: new object[] { 2, 1, "Get well soon!", 2, "Pending" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ApprovalRequests",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ApprovalRequests",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "LeaveRequests",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "LeaveRequests",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UserInfo",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "UserInfo",
                keyColumn: "Id",
                keyValue: "1");
        }
    }
}
