using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoePulse.API.Migrations.AuthDb
{
    /// <inheritdoc />
    public partial class AddAdmin2Role : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3d0d9a28-3994-42c8-947b-b7d8046c79d1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "10a5303d-de52-4f3a-99c0-e100ae626c9b", "926705c0-26b4-422a-a691-bada84205510" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "4db4f2cd-aef6-4559-bd90-8c2b0669f1ba", 0, "fee3eec3-259a-4df6-90d8-c0fa99eb24b4", "tamal.karmakar96@yahoo.com", false, false, null, "tamal.karmakar96@yahoo.com", "ADMIN2", null, null, false, "1a10af7a-111a-4f26-8d55-f755c40746e4", false, "admin2" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4db4f2cd-aef6-4559-bd90-8c2b0669f1ba");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3d0d9a28-3994-42c8-947b-b7d8046c79d1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "353a1da3-d9ff-4ef7-ba10-5bcc3071b162", "f6bf9082-99b4-4efe-9ede-990c32033eec" });
        }
    }
}
