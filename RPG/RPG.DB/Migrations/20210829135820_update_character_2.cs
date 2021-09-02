using Microsoft.EntityFrameworkCore.Migrations;

namespace RPG.Data.Migrations
{
    public partial class update_character_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Characters",
                table: "Character");

            migrationBuilder.AddColumn<int>(
                name: "Defeats",
                table: "Character",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Fights",
                table: "Character",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Victories",
                table: "Character",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Defeats",
                table: "Character");

            migrationBuilder.DropColumn(
                name: "Fights",
                table: "Character");

            migrationBuilder.DropColumn(
                name: "Victories",
                table: "Character");

            migrationBuilder.AddColumn<int>(
                name: "Characters",
                table: "Character",
                type: "int",
                nullable: true);
        }
    }
}
