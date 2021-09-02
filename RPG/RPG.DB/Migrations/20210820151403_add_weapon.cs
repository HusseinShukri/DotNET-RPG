using Microsoft.EntityFrameworkCore.Migrations;

namespace RPG.Data.Migrations
{
    public partial class add_weapon : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "Characters",
                table: "Character",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WeaponId",
                table: "Character",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Weapon",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Damage = table.Column<int>(type: "int", nullable: false),
                    CharacterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weapon", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Weapon_Character_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Character",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Weapon_CharacterId",
                table: "Weapon",
                column: "CharacterId",
                unique: true);

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

            migrationBuilder.DropTable(
                name: "Weapon");

            migrationBuilder.DropColumn(
                name: "Characters",
                table: "Character");

            migrationBuilder.DropColumn(
                name: "WeaponId",
                table: "Character");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Character",
                newName: "userId");

            migrationBuilder.RenameIndex(
                name: "IX_Character_UserId",
                table: "Character",
                newName: "IX_Character_userId");

            migrationBuilder.AddForeignKey(
                name: "FK_Character_User_userId",
                table: "Character",
                column: "userId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
