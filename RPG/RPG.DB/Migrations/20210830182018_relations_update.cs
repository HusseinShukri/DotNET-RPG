using Microsoft.EntityFrameworkCore.Migrations;

namespace RPG.Data.Migrations
{
    public partial class relations_update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Weapon_Character_CharacterId",
                table: "Weapon");

            migrationBuilder.DropIndex(
                name: "IX_Weapon_CharacterId",
                table: "Weapon");

            migrationBuilder.CreateIndex(
                name: "IX_Character_WeaponId",
                table: "Character",
                column: "WeaponId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Character_Weapon_WeaponId",
                table: "Character",
                column: "WeaponId",
                principalTable: "Weapon",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Character_Weapon_WeaponId",
                table: "Character");

            migrationBuilder.DropIndex(
                name: "IX_Character_WeaponId",
                table: "Character");

            migrationBuilder.CreateIndex(
                name: "IX_Weapon_CharacterId",
                table: "Weapon",
                column: "CharacterId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Weapon_Character_CharacterId",
                table: "Weapon",
                column: "CharacterId",
                principalTable: "Character",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
