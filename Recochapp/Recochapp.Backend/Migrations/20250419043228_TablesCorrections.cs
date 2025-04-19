using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Recochapp.Backend.Migrations
{
    /// <inheritdoc />
    public partial class TablesCorrections : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expense_Plan_PlanId",
                table: "Expense");

            migrationBuilder.DropForeignKey(
                name: "FK_Expense_Users_UserId",
                table: "Expense");

            migrationBuilder.DropForeignKey(
                name: "FK_Plan_Group_GroupId",
                table: "Plan");

            migrationBuilder.DropForeignKey(
                name: "FK_Plan_PlanDestination_PlanDestinationId",
                table: "Plan");

            migrationBuilder.DropForeignKey(
                name: "FK_PlanDestination_Establishment_EstablishmentId",
                table: "PlanDestination");

            migrationBuilder.DropForeignKey(
                name: "FK_PlanDestination_Place_PlaceId",
                table: "PlanDestination");

            migrationBuilder.DropForeignKey(
                name: "FK_Review_Establishment_EstablishmentId",
                table: "Review");

            migrationBuilder.DropForeignKey(
                name: "FK_Review_Users_UserId",
                table: "Review");

            migrationBuilder.DropForeignKey(
                name: "FK_UserGroup_Group_GroupId",
                table: "UserGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_UserGroup_Users_UserId",
                table: "UserGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_UserPreference_Preference_PreferenceId",
                table: "UserPreference");

            migrationBuilder.DropForeignKey(
                name: "FK_UserPreference_Users_UserId",
                table: "UserPreference");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserPreference",
                table: "UserPreference");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserGroup",
                table: "UserGroup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Review",
                table: "Review");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Preference",
                table: "Preference");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlanDestination",
                table: "PlanDestination");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Plan",
                table: "Plan");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Place",
                table: "Place");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Group",
                table: "Group");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Expense",
                table: "Expense");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Establishment",
                table: "Establishment");

            migrationBuilder.RenameTable(
                name: "UserPreference",
                newName: "UserPreferences");

            migrationBuilder.RenameTable(
                name: "UserGroup",
                newName: "UserGroups");

            migrationBuilder.RenameTable(
                name: "Review",
                newName: "Reviews");

            migrationBuilder.RenameTable(
                name: "Preference",
                newName: "Preferences");

            migrationBuilder.RenameTable(
                name: "PlanDestination",
                newName: "PlanDestinations");

            migrationBuilder.RenameTable(
                name: "Plan",
                newName: "Plans");

            migrationBuilder.RenameTable(
                name: "Place",
                newName: "Places");

            migrationBuilder.RenameTable(
                name: "Group",
                newName: "Groups");

            migrationBuilder.RenameTable(
                name: "Expense",
                newName: "Expenses");

            migrationBuilder.RenameTable(
                name: "Establishment",
                newName: "Establishments");

            migrationBuilder.RenameIndex(
                name: "IX_UserPreference_UserId",
                table: "UserPreferences",
                newName: "IX_UserPreferences_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserPreference_PreferenceId",
                table: "UserPreferences",
                newName: "IX_UserPreferences_PreferenceId");

            migrationBuilder.RenameIndex(
                name: "IX_UserGroup_UserId",
                table: "UserGroups",
                newName: "IX_UserGroups_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserGroup_GroupId",
                table: "UserGroups",
                newName: "IX_UserGroups_GroupId");

            migrationBuilder.RenameIndex(
                name: "IX_Review_UserId",
                table: "Reviews",
                newName: "IX_Reviews_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Review_EstablishmentId",
                table: "Reviews",
                newName: "IX_Reviews_EstablishmentId");

            migrationBuilder.RenameIndex(
                name: "IX_PlanDestination_PlaceId",
                table: "PlanDestinations",
                newName: "IX_PlanDestinations_PlaceId");

            migrationBuilder.RenameIndex(
                name: "IX_PlanDestination_EstablishmentId",
                table: "PlanDestinations",
                newName: "IX_PlanDestinations_EstablishmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Plan_PlanDestinationId",
                table: "Plans",
                newName: "IX_Plans_PlanDestinationId");

            migrationBuilder.RenameIndex(
                name: "IX_Plan_GroupId",
                table: "Plans",
                newName: "IX_Plans_GroupId");

            migrationBuilder.RenameIndex(
                name: "IX_Group_AccessCode",
                table: "Groups",
                newName: "IX_Groups_AccessCode");

            migrationBuilder.RenameIndex(
                name: "IX_Expense_UserId",
                table: "Expenses",
                newName: "IX_Expenses_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Expense_PlanId",
                table: "Expenses",
                newName: "IX_Expenses_PlanId");

            migrationBuilder.RenameIndex(
                name: "IX_Establishment_Email",
                table: "Establishments",
                newName: "IX_Establishments_Email");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserPreferences",
                table: "UserPreferences",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserGroups",
                table: "UserGroups",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reviews",
                table: "Reviews",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Preferences",
                table: "Preferences",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlanDestinations",
                table: "PlanDestinations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Plans",
                table: "Plans",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Places",
                table: "Places",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Groups",
                table: "Groups",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Expenses",
                table: "Expenses",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Establishments",
                table: "Establishments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_Plans_PlanId",
                table: "Expenses",
                column: "PlanId",
                principalTable: "Plans",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_Users_UserId",
                table: "Expenses",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_PlanDestinations_Establishments_EstablishmentId",
                table: "PlanDestinations",
                column: "EstablishmentId",
                principalTable: "Establishments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PlanDestinations_Places_PlaceId",
                table: "PlanDestinations",
                column: "PlaceId",
                principalTable: "Places",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Plans_Groups_GroupId",
                table: "Plans",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Plans_PlanDestinations_PlanDestinationId",
                table: "Plans",
                column: "PlanDestinationId",
                principalTable: "PlanDestinations",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Establishments_EstablishmentId",
                table: "Reviews",
                column: "EstablishmentId",
                principalTable: "Establishments",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Users_UserId",
                table: "Reviews",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_UserGroups_Groups_GroupId",
                table: "UserGroups",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_UserGroups_Users_UserId",
                table: "UserGroups",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_UserPreferences_Preferences_PreferenceId",
                table: "UserPreferences",
                column: "PreferenceId",
                principalTable: "Preferences",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_UserPreferences_Users_UserId",
                table: "UserPreferences",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_Plans_PlanId",
                table: "Expenses");

            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_Users_UserId",
                table: "Expenses");

            migrationBuilder.DropForeignKey(
                name: "FK_PlanDestinations_Establishments_EstablishmentId",
                table: "PlanDestinations");

            migrationBuilder.DropForeignKey(
                name: "FK_PlanDestinations_Places_PlaceId",
                table: "PlanDestinations");

            migrationBuilder.DropForeignKey(
                name: "FK_Plans_Groups_GroupId",
                table: "Plans");

            migrationBuilder.DropForeignKey(
                name: "FK_Plans_PlanDestinations_PlanDestinationId",
                table: "Plans");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Establishments_EstablishmentId",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Users_UserId",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_UserGroups_Groups_GroupId",
                table: "UserGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_UserGroups_Users_UserId",
                table: "UserGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_UserPreferences_Preferences_PreferenceId",
                table: "UserPreferences");

            migrationBuilder.DropForeignKey(
                name: "FK_UserPreferences_Users_UserId",
                table: "UserPreferences");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserPreferences",
                table: "UserPreferences");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserGroups",
                table: "UserGroups");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reviews",
                table: "Reviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Preferences",
                table: "Preferences");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Plans",
                table: "Plans");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlanDestinations",
                table: "PlanDestinations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Places",
                table: "Places");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Groups",
                table: "Groups");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Expenses",
                table: "Expenses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Establishments",
                table: "Establishments");

            migrationBuilder.RenameTable(
                name: "UserPreferences",
                newName: "UserPreference");

            migrationBuilder.RenameTable(
                name: "UserGroups",
                newName: "UserGroup");

            migrationBuilder.RenameTable(
                name: "Reviews",
                newName: "Review");

            migrationBuilder.RenameTable(
                name: "Preferences",
                newName: "Preference");

            migrationBuilder.RenameTable(
                name: "Plans",
                newName: "Plan");

            migrationBuilder.RenameTable(
                name: "PlanDestinations",
                newName: "PlanDestination");

            migrationBuilder.RenameTable(
                name: "Places",
                newName: "Place");

            migrationBuilder.RenameTable(
                name: "Groups",
                newName: "Group");

            migrationBuilder.RenameTable(
                name: "Expenses",
                newName: "Expense");

            migrationBuilder.RenameTable(
                name: "Establishments",
                newName: "Establishment");

            migrationBuilder.RenameIndex(
                name: "IX_UserPreferences_UserId",
                table: "UserPreference",
                newName: "IX_UserPreference_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserPreferences_PreferenceId",
                table: "UserPreference",
                newName: "IX_UserPreference_PreferenceId");

            migrationBuilder.RenameIndex(
                name: "IX_UserGroups_UserId",
                table: "UserGroup",
                newName: "IX_UserGroup_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserGroups_GroupId",
                table: "UserGroup",
                newName: "IX_UserGroup_GroupId");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_UserId",
                table: "Review",
                newName: "IX_Review_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_EstablishmentId",
                table: "Review",
                newName: "IX_Review_EstablishmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Plans_PlanDestinationId",
                table: "Plan",
                newName: "IX_Plan_PlanDestinationId");

            migrationBuilder.RenameIndex(
                name: "IX_Plans_GroupId",
                table: "Plan",
                newName: "IX_Plan_GroupId");

            migrationBuilder.RenameIndex(
                name: "IX_PlanDestinations_PlaceId",
                table: "PlanDestination",
                newName: "IX_PlanDestination_PlaceId");

            migrationBuilder.RenameIndex(
                name: "IX_PlanDestinations_EstablishmentId",
                table: "PlanDestination",
                newName: "IX_PlanDestination_EstablishmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Groups_AccessCode",
                table: "Group",
                newName: "IX_Group_AccessCode");

            migrationBuilder.RenameIndex(
                name: "IX_Expenses_UserId",
                table: "Expense",
                newName: "IX_Expense_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Expenses_PlanId",
                table: "Expense",
                newName: "IX_Expense_PlanId");

            migrationBuilder.RenameIndex(
                name: "IX_Establishments_Email",
                table: "Establishment",
                newName: "IX_Establishment_Email");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserPreference",
                table: "UserPreference",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserGroup",
                table: "UserGroup",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Review",
                table: "Review",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Preference",
                table: "Preference",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Plan",
                table: "Plan",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlanDestination",
                table: "PlanDestination",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Place",
                table: "Place",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Group",
                table: "Group",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Expense",
                table: "Expense",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Establishment",
                table: "Establishment",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Expense_Plan_PlanId",
                table: "Expense",
                column: "PlanId",
                principalTable: "Plan",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Expense_Users_UserId",
                table: "Expense",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Plan_Group_GroupId",
                table: "Plan",
                column: "GroupId",
                principalTable: "Group",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Plan_PlanDestination_PlanDestinationId",
                table: "Plan",
                column: "PlanDestinationId",
                principalTable: "PlanDestination",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_PlanDestination_Establishment_EstablishmentId",
                table: "PlanDestination",
                column: "EstablishmentId",
                principalTable: "Establishment",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PlanDestination_Place_PlaceId",
                table: "PlanDestination",
                column: "PlaceId",
                principalTable: "Place",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Review_Establishment_EstablishmentId",
                table: "Review",
                column: "EstablishmentId",
                principalTable: "Establishment",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Review_Users_UserId",
                table: "Review",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_UserGroup_Group_GroupId",
                table: "UserGroup",
                column: "GroupId",
                principalTable: "Group",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_UserGroup_Users_UserId",
                table: "UserGroup",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_UserPreference_Preference_PreferenceId",
                table: "UserPreference",
                column: "PreferenceId",
                principalTable: "Preference",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_UserPreference_Users_UserId",
                table: "UserPreference",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
