using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoePulse.API.Migrations.AuthDb
{
    /// <inheritdoc />
    public partial class AddAdminRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3d0d9a28-3994-42c8-947b-b7d8046c79d1", "3d0d9a28-3994-42c8-947b-b7d8046c79d1", "Admin", "ADMIN" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3d0d9a28-3994-42c8-947b-b7d8046c79d1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "353a1da3-d9ff-4ef7-ba10-5bcc3071b162", "f6bf9082-99b4-4efe-9ede-990c32033eec" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d0d9a28-3994-42c8-947b-b7d8046c79d1");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3d0d9a28-3994-42c8-947b-b7d8046c79d1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "73aed49c-e2e4-4773-b8be-a65e976b485c", "3187532d-164e-45f9-8230-46d3a0f57e20" });
        }
    }
}
