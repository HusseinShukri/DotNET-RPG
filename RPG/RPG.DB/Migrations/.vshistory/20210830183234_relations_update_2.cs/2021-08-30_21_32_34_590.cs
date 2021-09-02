using Microsoft.EntityFrameworkCore.Migrations;

namespace RPG.Data.Migrations
{
    public partial class relations_update_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Character_WeaponId",
                table: "Character");

            migrationBuilder.CreateIndex(
                name: "IX_Weapon_CharacterId",
                table: "Weapon",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_Character_WeaponId",
                table: "Character",
                column: "WeaponId");

            migrationBuilder.AddForeignKey(
                name: "FK_Weapon_Character_CharacterId",
                table: "Weapon",
                column: "CharacterId",
                principalTable: "Character",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Weapon_Character_CharacterId",
                table: "Weapon");

            migrationBuilder.DropIndex(
                name: "IX_Weapon_CharacterId",
                table: "Weapon");

            migrationBuilder.DropIndex(
                name: "IX_Character_WeaponId",
                table: "Character");

            migrationBuilder.CreateIndex(
                name: "IX_Character_WeaponId",
                table: "Character",
                column: "WeaponId",
                unique: true);
        }
    }
}
