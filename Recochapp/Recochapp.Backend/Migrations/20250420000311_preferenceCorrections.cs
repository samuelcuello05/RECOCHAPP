using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Recochapp.Backend.Migrations
{
    /// <inheritdoc />
    public partial class preferenceCorrections : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Plans_Establishments_EstablishmentId",
                table: "Plans");

            migrationBuilder.DropForeignKey(
                name: "FK_Plans_Groups_GroupId",
                table: "Plans");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Preferences");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Preferences");

            migrationBuilder.AddColumn<string>(
                name: "Activity",
                table: "Preferences",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Budget",
                table: "Preferences",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Preferences",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "GroupId",
                table: "Plans",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "EstablishmentId",
                table: "Plans",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Activity",
                table: "Plans",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Plans_Establishments_EstablishmentId",
                table: "Plans",
                column: "EstablishmentId",
                principalTable: "Establishments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Plans_Groups_GroupId",
                table: "Plans",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Plans_Establishments_EstablishmentId",
                table: "Plans");

            migrationBuilder.DropForeignKey(
                name: "FK_Plans_Groups_GroupId",
                table: "Plans");

            migrationBuilder.DropColumn(
                name: "Activity",
                table: "Preferences");

            migrationBuilder.DropColumn(
                name: "Budget",
                table: "Preferences");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "Preferences");

            migrationBuilder.DropColumn(
                name: "Activity",
                table: "Plans");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Preferences",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Preferences",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "GroupId",
                table: "Plans",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EstablishmentId",
                table: "Plans",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Plans_Establishments_EstablishmentId",
                table: "Plans",
                column: "EstablishmentId",
                principalTable: "Establishments",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Plans_Groups_GroupId",
                table: "Plans",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
