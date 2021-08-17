using Microsoft.EntityFrameworkCore.Migrations;

namespace RPG.Data.Migrations
{
    public partial class userCharacterRelashinship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Character",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Character_UserId",
                table: "Character",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Character_User_UserId",
                table: "Character",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Character_User_UserId",
                table: "Character");

            migrationBuilder.DropIndex(
                name: "IX_Character_UserId",
                table: "Character");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Character");
        }
    }
}
