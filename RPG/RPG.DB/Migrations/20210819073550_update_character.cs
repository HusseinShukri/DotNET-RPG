using Microsoft.EntityFrameworkCore.Migrations;

namespace RPG.Data.Migrations
{
    public partial class update_character : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Character_User_UserId",
                table: "Character");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Character",
                newName: "userId");

            migrationBuilder.RenameIndex(
                name: "IX_Character_UserId",
                table: "Character",
                newName: "IX_Character_userId");

            migrationBuilder.AlterColumn<int>(
                name: "userId",
                table: "Character",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Character_User_userId",
                table: "Character",
                column: "userId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Character_User_userId",
                table: "Character");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "Character",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Character_userId",
                table: "Character",
                newName: "IX_Character_UserId");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Character",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Character_User_UserId",
                table: "Character",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
