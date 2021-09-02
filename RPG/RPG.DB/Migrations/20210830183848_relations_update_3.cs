using Microsoft.EntityFrameworkCore.Migrations;

namespace RPG.Data.Migrations
{
    public partial class relations_update_3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Character_Weapon_WeaponId",
                table: "Character");

            migrationBuilder.DropIndex(
                name: "IX_Weapon_CharacterId",
                table: "Weapon");

            migrationBuilder.DropIndex(
                name: "IX_Character_WeaponId",
                table: "Character");

            migrationBuilder.DropColumn(
                name: "WeaponId",
                table: "Character");

            migrationBuilder.CreateIndex(
                name: "IX_Weapon_CharacterId",
                table: "Weapon",
                column: "CharacterId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Weapon_CharacterId",
                table: "Weapon");

            migrationBuilder.AddColumn<int>(
                name: "WeaponId",
                table: "Character",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Weapon_CharacterId",
                table: "Weapon",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_Character_WeaponId",
                table: "Character",
                column: "WeaponId");

            migrationBuilder.AddForeignKey(
                name: "FK_Character_Weapon_WeaponId",
                table: "Character",
                column: "WeaponId",
                principalTable: "Weapon",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
