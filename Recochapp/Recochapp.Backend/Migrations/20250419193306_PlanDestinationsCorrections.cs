using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Recochapp.Backend.Migrations
{
    /// <inheritdoc />
    public partial class PlanDestinationsCorrections : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Plans_PlanDestinations_PlanDestinationId",
                table: "Plans");

            migrationBuilder.DropTable(
                name: "PlanDestinations");

            migrationBuilder.DropTable(
                name: "Places");

            migrationBuilder.DropColumn(
                name: "PlanDestinationType",
                table: "Plans");

            migrationBuilder.RenameColumn(
                name: "PlanDestinationId",
                table: "Plans",
                newName: "EstablishmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Plans_PlanDestinationId",
                table: "Plans",
                newName: "IX_Plans_EstablishmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Plans_Establishments_EstablishmentId",
                table: "Plans",
                column: "EstablishmentId",
                principalTable: "Establishments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Plans_Establishments_EstablishmentId",
                table: "Plans");

            migrationBuilder.RenameColumn(
                name: "EstablishmentId",
                table: "Plans",
                newName: "PlanDestinationId");

            migrationBuilder.RenameIndex(
                name: "IX_Plans_EstablishmentId",
                table: "Plans",
                newName: "IX_Plans_PlanDestinationId");

            migrationBuilder.AddColumn<string>(
                name: "PlanDestinationType",
                table: "Plans",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Places",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Location = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Places", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlanDestinations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstablishmentId = table.Column<int>(type: "int", nullable: true),
                    PlaceId = table.Column<int>(type: "int", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanDestinations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlanDestinations_Establishments_EstablishmentId",
                        column: x => x.EstablishmentId,
                        principalTable: "Establishments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PlanDestinations_Places_PlaceId",
                        column: x => x.PlaceId,
                        principalTable: "Places",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlanDestinations_EstablishmentId",
                table: "PlanDestinations",
                column: "EstablishmentId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanDestinations_PlaceId",
                table: "PlanDestinations",
                column: "PlaceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Plans_PlanDestinations_PlanDestinationId",
                table: "Plans",
                column: "PlanDestinationId",
                principalTable: "PlanDestinations",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
