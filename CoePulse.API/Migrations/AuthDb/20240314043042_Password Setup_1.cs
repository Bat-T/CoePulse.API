using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CoePulse.API.Migrations.AuthDb
{
    /// <inheritdoc />
    public partial class PasswordSetup_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "dcb8c120-4f0a-47eb-b536-98a65f0d5d6a", "3d0d9a28-3994-42c8-947b-b7d8046c79d1" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "de72a30c-4259-4947-b774-f94fcdc5ae86", "3d0d9a28-3994-42c8-947b-b7d8046c79d1" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3d0d9a28-3994-42c8-947b-b7d8046c79d1");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4db4f2cd-aef6-4559-bd90-8c2b0669f1ba",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ea34e0fb-ee66-4be6-af05-734766f69496", "AQAAAAIAAYagAAAAEKlLvTmpSap8i6HDhd+e339xEU5Po+2bLvKHYg/Er/dseMjo7oP51EmDf9LuOWV2ig==", "40285648-c646-4dce-bc86-eb09fcaca378" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "65a5745e-d18a-4853-bfa7-84e87c7afb65", 0, "202f5be0-3036-4591-aedd-471cd26cb428", "tamal.karmakar96_1@yahoo.com", false, false, null, "tamal.karmakar96_1@yahoo.com", "ADMIN", "AQAAAAIAAYagAAAAEDs6TznJNz3GsSPvOj92nQqvcOSEkEMdBzUs5gTA5QXEkl42l5G+W1jXgMkYLdrirQ==", null, false, "0bee1bbd-719d-42d0-ac4b-c5f70f1497f4", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "3d0d9a28-3994-42c8-947b-b7d8046c79d1", "65a5745e-d18a-4853-bfa7-84e87c7afb65" },
                    { "dcb8c120-4f0a-47eb-b536-98a65f0d5d6a", "65a5745e-d18a-4853-bfa7-84e87c7afb65" },
                    { "de72a30c-4259-4947-b774-f94fcdc5ae86", "65a5745e-d18a-4853-bfa7-84e87c7afb65" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3d0d9a28-3994-42c8-947b-b7d8046c79d1", "65a5745e-d18a-4853-bfa7-84e87c7afb65" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "dcb8c120-4f0a-47eb-b536-98a65f0d5d6a", "65a5745e-d18a-4853-bfa7-84e87c7afb65" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "de72a30c-4259-4947-b774-f94fcdc5ae86", "65a5745e-d18a-4853-bfa7-84e87c7afb65" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "65a5745e-d18a-4853-bfa7-84e87c7afb65");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4db4f2cd-aef6-4559-bd90-8c2b0669f1ba",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d66ce3ed-12ac-4580-8db2-b088de09dc6f", "AQAAAAIAAYagAAAAECU2FH51HUHIOzVtK9XC9W5XUF9UitEn3ch32l3121CU69s5dpV5Bu5Xlx7lxOSnUA==", "2564c8b1-252c-402f-bf12-4030a68edf37" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "3d0d9a28-3994-42c8-947b-b7d8046c79d1", 0, "8fabd7f2-946b-4e4a-a8b8-27ecc5c2eda6", "tamal.karmakar96_1@yahoo.com", false, false, null, "tamal.karmakar96_1@yahoo.com", "ADMIN", "AQAAAAIAAYagAAAAEJlhzrUk4E8X/H+xL3eDQ3BavZtmlFPLUtvggJwdokgtOKTI8BOZsGrMtwmKv4E4qQ==", null, false, "a242406f-9561-4dd3-af1a-4b5f26a63fec", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "dcb8c120-4f0a-47eb-b536-98a65f0d5d6a", "3d0d9a28-3994-42c8-947b-b7d8046c79d1" },
                    { "de72a30c-4259-4947-b774-f94fcdc5ae86", "3d0d9a28-3994-42c8-947b-b7d8046c79d1" }
                });
        }
    }
}
