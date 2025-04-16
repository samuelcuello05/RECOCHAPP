using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Recochapp.Backend.Migrations
{
    /// <inheritdoc />
    public partial class RelationshipsAndAtributes_correrctions_and_new_table_UserGroup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PlanDestinationId",
                table: "PlanDestination");

            migrationBuilder.RenameColumn(
                name: "PlanDestinationName",
                table: "Plan",
                newName: "PlanDestinationType");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "PlanDestination",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "MembersQuantity",
                table: "Group",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "UserGroup",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    GroupId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGroup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserGroup_Group_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Group",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_UserGroup_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserGroup_GroupId",
                table: "UserGroup",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_UserGroup_UserId",
                table: "UserGroup",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserGroup");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "PlanDestination");

            migrationBuilder.DropColumn(
                name: "MembersQuantity",
                table: "Group");

            migrationBuilder.RenameColumn(
                name: "PlanDestinationType",
                table: "Plan",
                newName: "PlanDestinationName");

            migrationBuilder.AddColumn<int>(
                name: "PlanDestinationId",
                table: "PlanDestination",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
