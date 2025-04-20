using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Recochapp.Backend.Migrations
{
    /// <inheritdoc />
    public partial class userpreferencesCorrections : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserPreferences_Users_UserId",
                table: "UserPreferences");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "UserPreferences",
                newName: "PlanId");

            migrationBuilder.RenameIndex(
                name: "IX_UserPreferences_UserId",
                table: "UserPreferences",
                newName: "IX_UserPreferences_PlanId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserPreferences_Plans_PlanId",
                table: "UserPreferences",
                column: "PlanId",
                principalTable: "Plans",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserPreferences_Plans_PlanId",
                table: "UserPreferences");

            migrationBuilder.RenameColumn(
                name: "PlanId",
                table: "UserPreferences",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserPreferences_PlanId",
                table: "UserPreferences",
                newName: "IX_UserPreferences_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserPreferences_Users_UserId",
                table: "UserPreferences",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
