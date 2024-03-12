using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookStoreApp.API.Migrations
{
    /// <inheritdoc />
    public partial class SeededDefaultUserandRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "53bde38f-cfd7-49d5-aaf5-dec0577b9194", null, "Administrator", "ADMINISTRATOR" },
                    { "781d5294-ceaf-40cb-a5a0-d67d0d1d742f", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "a9cafc2e-7313-43e7-9ff8-94be0f30b528", 0, "98fbdc88-e198-4eb8-ac38-e7af6f729ba5", "admin@bookstore.com", false, "System", "Admin", false, null, "ADMIN@BOOKSTORE.COM", "ADMIN@BOOKSTORE.COM", "AQAAAAIAAYagAAAAEMkmgopUMlDMlX8qVliS8FZFcHhunXbLB+gLiluFXnCfgldiEeyIVBfBLu3Ji+f9BQ==", null, false, "237d55c7-1415-44a2-b2fd-c1088691aea0", false, "admin@bookstore.com" },
                    { "f5ec879c-b0b0-4292-a3a6-7628377f696a", 0, "1264d68f-f967-4395-8a2b-cd315c52dd99", "user@bookstore.com", false, "System", "User", false, null, "USER@BOOKSTORE.COM", "USER@BOOKSTORE.COM", "AQAAAAIAAYagAAAAEFLZ6/YNX6HplUbTOKDC4MmOTF+skAjBi1W/HCE7HyEPhiCHOgnfH+lyoCQNYy19jw==", null, false, "fc5e9480-03de-4786-8d20-e12809085197", false, "user@bookstore.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "53bde38f-cfd7-49d5-aaf5-dec0577b9194", "f5ec879c-b0b0-4292-a3a6-7628377f696a" },
                    { "781d5294-ceaf-40cb-a5a0-d67d0d1d742f", "f5ec879c-b0b0-4292-a3a6-7628377f696a" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "53bde38f-cfd7-49d5-aaf5-dec0577b9194", "f5ec879c-b0b0-4292-a3a6-7628377f696a" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "781d5294-ceaf-40cb-a5a0-d67d0d1d742f", "f5ec879c-b0b0-4292-a3a6-7628377f696a" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a9cafc2e-7313-43e7-9ff8-94be0f30b528");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "53bde38f-cfd7-49d5-aaf5-dec0577b9194");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "781d5294-ceaf-40cb-a5a0-d67d0d1d742f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f5ec879c-b0b0-4292-a3a6-7628377f696a");
        }
    }
}
