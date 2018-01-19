using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CriticalMiss.Data.Migrations
{
    public partial class AfterGamename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Boards_Games_GameId",
                schema: "CM",
                table: "Boards");

            migrationBuilder.DropIndex(
                name: "IX_Boards_GameId",
                schema: "CM",
                table: "Boards");

            migrationBuilder.DropColumn(
                name: "GameId",
                schema: "CM",
                table: "Boards");

            migrationBuilder.AlterColumn<double>(
                name: "PixelWidth",
                schema: "CM",
                table: "Items",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<double>(
                name: "PixelHeight",
                schema: "CM",
                table: "Items",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "GameName",
                schema: "CM",
                table: "Games",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "GameName",
                schema: "CM",
                table: "Boards",
                nullable: true);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Games_GameName",
                schema: "CM",
                table: "Games",
                column: "GameName");

            migrationBuilder.CreateIndex(
                name: "IX_Boards_GameName",
                schema: "CM",
                table: "Boards",
                column: "GameName");

            migrationBuilder.AddForeignKey(
                name: "FK_Boards_Games_GameName",
                schema: "CM",
                table: "Boards",
                column: "GameName",
                principalSchema: "CM",
                principalTable: "Games",
                principalColumn: "GameName",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Boards_Games_GameName",
                schema: "CM",
                table: "Boards");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Games_GameName",
                schema: "CM",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Boards_GameName",
                schema: "CM",
                table: "Boards");

            migrationBuilder.DropColumn(
                name: "GameName",
                schema: "CM",
                table: "Boards");

            migrationBuilder.AlterColumn<int>(
                name: "PixelWidth",
                schema: "CM",
                table: "Items",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<int>(
                name: "PixelHeight",
                schema: "CM",
                table: "Items",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<string>(
                name: "GameName",
                schema: "CM",
                table: "Games",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "GameId",
                schema: "CM",
                table: "Boards",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Boards_GameId",
                schema: "CM",
                table: "Boards",
                column: "GameId");

            migrationBuilder.AddForeignKey(
                name: "FK_Boards_Games_GameId",
                schema: "CM",
                table: "Boards",
                column: "GameId",
                principalSchema: "CM",
                principalTable: "Games",
                principalColumn: "GameId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
