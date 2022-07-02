using Microsoft.EntityFrameworkCore.Migrations;

namespace MySoccerWorld.Data.Migrations
{
    public partial class UpdateAwards : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SeasonalAwards_PlayerTeams_PlayerTeamId",
                table: "SeasonalAwards");

            migrationBuilder.AlterColumn<int>(
                name: "PlayerTeamId",
                table: "SeasonalAwards",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CoachId",
                table: "SeasonalAwards",
                type: "int",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SeasonalAwards_PlayerTeams_PlayerTeamId",
                table: "SeasonalAwards",
                column: "PlayerTeamId",
                principalTable: "PlayerTeams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SeasonalAwards_PlayerTeams_PlayerTeamId",
                table: "SeasonalAwards");

            migrationBuilder.DropColumn(
                name: "CoachId",
                table: "SeasonalAwards");

            migrationBuilder.AlterColumn<int>(
                name: "PlayerTeamId",
                table: "SeasonalAwards",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SeasonalAwards_PlayerTeams_PlayerTeamId",
                table: "SeasonalAwards",
                column: "PlayerTeamId",
                principalTable: "PlayerTeams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
