using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCOREWEB.Migrations
{
    /// <inheritdoc />
    public partial class SeedingAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Role", "UserEmail", "UserName", "password" },
                values: new object[] { 100, "SuperAdmin", "AppDomain@kiit.ac.in", "Super-Admin", "Lpq236PaLVyM3AgXVlxdwdL389Z33zPCw7rWN9PferM=" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 100);
        }
    }
}
