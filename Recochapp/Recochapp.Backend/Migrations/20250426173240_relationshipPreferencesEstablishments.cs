using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Recochapp.Backend.Migrations
{
    /// <inheritdoc />
    public partial class relationshipPreferencesEstablishments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EstablishmentId",
                table: "Preferences",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Preferences_EstablishmentId",
                table: "Preferences",
                column: "EstablishmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Preferences_Establishments_EstablishmentId",
                table: "Preferences",
                column: "EstablishmentId",
                principalTable: "Establishments",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Preferences_Establishments_EstablishmentId",
                table: "Preferences");

            migrationBuilder.DropIndex(
                name: "IX_Preferences_EstablishmentId",
                table: "Preferences");

            migrationBuilder.DropColumn(
                name: "EstablishmentId",
                table: "Preferences");
        }
    }
}
