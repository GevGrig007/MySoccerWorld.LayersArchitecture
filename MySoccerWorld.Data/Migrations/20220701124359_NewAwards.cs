using Microsoft.EntityFrameworkCore.Migrations;

namespace MySoccerWorld.Data.Migrations
{
    public partial class NewAwards : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SeasonalAwards_CoachTeams_BestCoachId",
                table: "SeasonalAwards");

            migrationBuilder.RenameColumn(
                name: "BestCoachId",
                table: "SeasonalAwards",
                newName: "CoachTeamId");

            migrationBuilder.RenameIndex(
                name: "IX_SeasonalAwards_BestCoachId",
                table: "SeasonalAwards",
                newName: "IX_SeasonalAwards_CoachTeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_SeasonalAwards_CoachTeams_CoachTeamId",
                table: "SeasonalAwards",
                column: "CoachTeamId",
                principalTable: "CoachTeams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SeasonalAwards_CoachTeams_CoachTeamId",
                table: "SeasonalAwards");

            migrationBuilder.RenameColumn(
                name: "CoachTeamId",
                table: "SeasonalAwards",
                newName: "BestCoachId");

            migrationBuilder.RenameIndex(
                name: "IX_SeasonalAwards_CoachTeamId",
                table: "SeasonalAwards",
                newName: "IX_SeasonalAwards_BestCoachId");

            migrationBuilder.AddForeignKey(
                name: "FK_SeasonalAwards_CoachTeams_BestCoachId",
                table: "SeasonalAwards",
                column: "BestCoachId",
                principalTable: "CoachTeams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
