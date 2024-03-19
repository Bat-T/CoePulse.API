using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoePulse.API.Migrations.AuthDb
{
    /// <inheritdoc />
    public partial class PasswordSetup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3d0d9a28-3994-42c8-947b-b7d8046c79d1",
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8fabd7f2-946b-4e4a-a8b8-27ecc5c2eda6", "tamal.karmakar96_1@yahoo.com", "tamal.karmakar96_1@yahoo.com", "AQAAAAIAAYagAAAAEJlhzrUk4E8X/H+xL3eDQ3BavZtmlFPLUtvggJwdokgtOKTI8BOZsGrMtwmKv4E4qQ==", "a242406f-9561-4dd3-af1a-4b5f26a63fec" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4db4f2cd-aef6-4559-bd90-8c2b0669f1ba",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d66ce3ed-12ac-4580-8db2-b088de09dc6f", "AQAAAAIAAYagAAAAECU2FH51HUHIOzVtK9XC9W5XUF9UitEn3ch32l3121CU69s5dpV5Bu5Xlx7lxOSnUA==", "2564c8b1-252c-402f-bf12-4030a68edf37" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3d0d9a28-3994-42c8-947b-b7d8046c79d1",
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "PasswordHash", "SecurityStamp" },
                values: new object[] { "10a5303d-de52-4f3a-99c0-e100ae626c9b", "tamal.karmakar96@yahoo.com", "tamal.karmakar96@yahoo.com", null, "926705c0-26b4-422a-a691-bada84205510" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4db4f2cd-aef6-4559-bd90-8c2b0669f1ba",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fee3eec3-259a-4df6-90d8-c0fa99eb24b4", null, "1a10af7a-111a-4f26-8d55-f755c40746e4" });
        }
    }
}
