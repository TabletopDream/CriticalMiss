using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CriticalMiss.Data.Migrations
{
    public partial class MigrateforInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LocalId",
                schema: "CM",
                table: "GameBoardItem",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BoardId",
                schema: "CM",
                table: "GameBoard",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "BoardName",
                schema: "CM",
                table: "GameBoard",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ItemCount",
                schema: "CM",
                table: "GameBoard",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LocalId",
                schema: "CM",
                table: "GameBoard",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Pixel",
                schema: "CM",
                table: "GameBoard",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "GameBoard",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BoardName = table.Column<string>(nullable: true),
                    GameId = table.Column<int>(nullable: false),
                    Height = table.Column<int>(nullable: false),
                    ItemCount = table.Column<int>(nullable: false),
                    LocalId = table.Column<int>(nullable: false),
                    Pixel = table.Column<int>(nullable: false),
                    Width = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameBoard", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "item",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GameBoardId = table.Column<int>(nullable: false),
                    PixelHeight = table.Column<int>(nullable: false),
                    ImageAssetId = table.Column<int>(nullable: false),
                    IsToken = table.Column<bool>(nullable: false),
                    LocalId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    PixelWidth = table.Column<int>(nullable: false),
                    XPosition = table.Column<int>(nullable: false),
                    YPosition = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_item", x => x.ID);
                    table.ForeignKey(
                        name: "FK_item_GameBoard_GameBoardId",
                        column: x => x.GameBoardId,
                        principalSchema: "CM",
                        principalTable: "GameBoard",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_item_ImageAsset_ImageAssetId",
                        column: x => x.ImageAssetId,
                        principalSchema: "CM",
                        principalTable: "ImageAsset",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_item_GameBoardId",
                table: "item",
                column: "GameBoardId");

            migrationBuilder.CreateIndex(
                name: "IX_item_ImageAssetId",
                table: "item",
                column: "ImageAssetId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameBoard");

            migrationBuilder.DropTable(
                name: "item");

            migrationBuilder.DropColumn(
                name: "LocalId",
                schema: "CM",
                table: "GameBoardItem");

            migrationBuilder.DropColumn(
                name: "BoardId",
                schema: "CM",
                table: "GameBoard");

            migrationBuilder.DropColumn(
                name: "BoardName",
                schema: "CM",
                table: "GameBoard");

            migrationBuilder.DropColumn(
                name: "ItemCount",
                schema: "CM",
                table: "GameBoard");

            migrationBuilder.DropColumn(
                name: "LocalId",
                schema: "CM",
                table: "GameBoard");

            migrationBuilder.DropColumn(
                name: "Pixel",
                schema: "CM",
                table: "GameBoard");
        }
    }
}
