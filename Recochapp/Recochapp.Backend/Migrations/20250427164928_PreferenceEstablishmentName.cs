using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Recochapp.Backend.Migrations
{
    /// <inheritdoc />
    public partial class PreferenceEstablishmentName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EstablishmentName",
                table: "Preferences",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EstablishmentName",
                table: "Preferences");
        }
    }
}
