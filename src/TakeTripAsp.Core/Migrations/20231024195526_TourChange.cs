using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TakeTripAsp.Core.Migrations
{
    /// <inheritdoc />
    public partial class TourChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "cda07bf4-86b9-4bc9-87c6-614de75c910e", "7a90e5ea-59b7-4198-a62d-7b15d27e64fd" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ad0238cf-6b66-4473-a805-1ff022d7e7ca", "987266f1-f159-4c44-b6e8-39f11b22c172" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "e46d5156-c5bb-4e10-9d7d-13fd6375c0ad", "ebb5f25f-1df6-494b-8a58-1d6848582a8f" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ad0238cf-6b66-4473-a805-1ff022d7e7ca");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cda07bf4-86b9-4bc9-87c6-614de75c910e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e46d5156-c5bb-4e10-9d7d-13fd6375c0ad");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7a90e5ea-59b7-4198-a62d-7b15d27e64fd");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "987266f1-f159-4c44-b6e8-39f11b22c172");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ebb5f25f-1df6-494b-8a58-1d6848582a8f");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Tours",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Continent",
                table: "Tours",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "789cb115-cefe-45a0-becd-744f8258913b", null, "client", "CLIENT" },
                    { "a1cd0b7d-75bb-42ce-a4ee-935e5c3a0355", null, "admin", "ADMIN" },
                    { "f23b441e-e537-464d-8448-0102702333c6", null, "seller", "SELLER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CoverPath", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "483d0381-042d-4f15-9a74-e71117609207", 0, "c67a9c94-5422-4dd7-b03b-cad41e1f7b00", "\\img\\user\\user.jpg", new DateTime(1998, 10, 24, 22, 55, 26, 39, DateTimeKind.Local).AddTicks(9258), "client@taketrip.com", true, "Oleksandr", "Shevchenko", false, null, "CLIENT@TAKETRIP.COM", "OLEKSANDR", "AQAAAAIAAYagAAAAEH0EQokutxH3I5v4XjAGnVP4o4KTiUFWFNDSAzSPkH91CSyGSFj50zcPdfC9PIG0Ig==", null, false, "12b736cb-f275-4f47-b1ee-9cedcf6121cb", false, "Oleksandr" },
                    { "a3778287-d769-4899-b1eb-596f6d38c6e8", 0, "40da444d-bad1-4bbb-a72a-850bec02d35f", "\\img\\user\\user.jpg", new DateTime(1998, 10, 24, 22, 55, 25, 922, DateTimeKind.Local).AddTicks(7023), "admin@taketrip.com", true, "Mariia", "Kovalchuk", false, null, "ADMIN@TAKETRIP.COM", "MARIIA", "AQAAAAIAAYagAAAAEGzWrBD0YXQniypkkwzzfkbDRcF/mngXox8YCW6gmCHVA6j4p4NBJDsEudl3erGrTw==", null, false, "2921cd48-53a1-460a-a0ae-e51e208c87ae", false, "Mariia" },
                    { "f6df872d-e0a2-4120-a4b7-57f7a67c59f9", 0, "b679ee2e-71e2-4ece-8bda-02a1d550ec25", "\\img\\user\\user.jpg", new DateTime(1998, 10, 24, 22, 55, 25, 981, DateTimeKind.Local).AddTicks(4060), "seller@taketrip.com", true, "Ivan", "Petrovych", false, null, "SELLER@TAKETRIP.COM", "IVAN", "AQAAAAIAAYagAAAAEJsJGTUDzCVfcP87zIOeW16WUPc8Vm8/VCi8OnyJFn2bqSxKCCDjKeO9lQ+RXALnHQ==", null, false, "86e17eaa-59a1-4385-a615-d572f96c8dd9", false, "Ivan" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "789cb115-cefe-45a0-becd-744f8258913b", "483d0381-042d-4f15-9a74-e71117609207" },
                    { "a1cd0b7d-75bb-42ce-a4ee-935e5c3a0355", "a3778287-d769-4899-b1eb-596f6d38c6e8" },
                    { "f23b441e-e537-464d-8448-0102702333c6", "f6df872d-e0a2-4120-a4b7-57f7a67c59f9" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "789cb115-cefe-45a0-becd-744f8258913b", "483d0381-042d-4f15-9a74-e71117609207" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "a1cd0b7d-75bb-42ce-a4ee-935e5c3a0355", "a3778287-d769-4899-b1eb-596f6d38c6e8" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f23b441e-e537-464d-8448-0102702333c6", "f6df872d-e0a2-4120-a4b7-57f7a67c59f9" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "789cb115-cefe-45a0-becd-744f8258913b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a1cd0b7d-75bb-42ce-a4ee-935e5c3a0355");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f23b441e-e537-464d-8448-0102702333c6");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "483d0381-042d-4f15-9a74-e71117609207");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a3778287-d769-4899-b1eb-596f6d38c6e8");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f6df872d-e0a2-4120-a4b7-57f7a67c59f9");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Tours");

            migrationBuilder.DropColumn(
                name: "Continent",
                table: "Tours");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "ad0238cf-6b66-4473-a805-1ff022d7e7ca", null, "admin", "ADMIN" },
                    { "cda07bf4-86b9-4bc9-87c6-614de75c910e", null, "seller", "SELLER" },
                    { "e46d5156-c5bb-4e10-9d7d-13fd6375c0ad", null, "client", "CLIENT" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CoverPath", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "7a90e5ea-59b7-4198-a62d-7b15d27e64fd", 0, "1bf2a2cc-0e80-46c1-a769-11276277bac5", "\\img\\user\\user.jpg", new DateTime(1998, 10, 19, 17, 11, 50, 24, DateTimeKind.Local).AddTicks(9709), "seller@taketrip.com", true, "Ivan", "Petrovych", false, null, "SELLER@TAKETRIP.COM", "IVAN", "AQAAAAIAAYagAAAAENlcVQ8mtaIYIEQQXrBY61wpFCdnjLib4vekp5gWcLZCBzc0yuyHVhARvMII1NnZcw==", null, false, "2f1da337-965a-498e-8ff5-62181d8ab78b", false, "Ivan" },
                    { "987266f1-f159-4c44-b6e8-39f11b22c172", 0, "f70182f2-30e3-4f17-9a4c-bfd9b145bdca", "\\img\\user\\user.jpg", new DateTime(1998, 10, 19, 17, 11, 49, 960, DateTimeKind.Local).AddTicks(7300), "admin@taketrip.com", true, "Mariia", "Kovalchuk", false, null, "ADMIN@TAKETRIP.COM", "MARIIA", "AQAAAAIAAYagAAAAEPEqXI8aCKccJmKZTWbU9PmF7DrDZiZi9UPXoywOLpQIChrXb1fc+KMCayOtZ/xYhA==", null, false, "21a4c821-bae9-4cd7-8b6a-ce1bca0d2067", false, "Mariia" },
                    { "ebb5f25f-1df6-494b-8a58-1d6848582a8f", 0, "a25e8783-4eb0-494a-b1b7-580d8219cd24", "\\img\\user\\user.jpg", new DateTime(1998, 10, 19, 17, 11, 50, 94, DateTimeKind.Local).AddTicks(7508), "client@taketrip.com", true, "Oleksandr", "Shevchenko", false, null, "CLIENT@TAKETRIP.COM", "OLEKSANDR", "AQAAAAIAAYagAAAAEFvnwUvsLMm7p1+eAczjukfBAukUxx2xNShNcF6S5u4BRiZJFdHMw5FPl6I04c0N6Q==", null, false, "0b400a64-426c-4109-82b9-ccb20249b1dd", false, "Oleksandr" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "cda07bf4-86b9-4bc9-87c6-614de75c910e", "7a90e5ea-59b7-4198-a62d-7b15d27e64fd" },
                    { "ad0238cf-6b66-4473-a805-1ff022d7e7ca", "987266f1-f159-4c44-b6e8-39f11b22c172" },
                    { "e46d5156-c5bb-4e10-9d7d-13fd6375c0ad", "ebb5f25f-1df6-494b-8a58-1d6848582a8f" }
                });
        }
    }
}
