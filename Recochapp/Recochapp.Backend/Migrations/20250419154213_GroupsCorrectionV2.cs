using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Recochapp.Backend.Migrations
{
    /// <inheritdoc />
    public partial class GroupsCorrectionV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Groups_AccessCode",
                table: "Groups");

            migrationBuilder.AlterColumn<string>(
                name: "AccessCode",
                table: "Groups",
                type: "nvarchar(8)",
                maxLength: 8,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(8)",
                oldMaxLength: 8);

            migrationBuilder.CreateIndex(
                name: "IX_Groups_AccessCode",
                table: "Groups",
                column: "AccessCode",
                unique: true,
                filter: "[AccessCode] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Groups_AccessCode",
                table: "Groups");

            migrationBuilder.AlterColumn<string>(
                name: "AccessCode",
                table: "Groups",
                type: "nvarchar(8)",
                maxLength: 8,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(8)",
                oldMaxLength: 8,
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Groups_AccessCode",
                table: "Groups",
                column: "AccessCode",
                unique: true);
        }
    }
}
