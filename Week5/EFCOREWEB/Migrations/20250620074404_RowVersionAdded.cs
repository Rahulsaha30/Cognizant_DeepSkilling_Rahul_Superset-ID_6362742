using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCOREWEB.Migrations
{
    /// <inheritdoc />
    public partial class RowVersionAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "RowVerion",
                table: "Students",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RowVerion",
                table: "Students");
        }
    }
}
