using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CriticalMiss.Data.Migrations
{
    public partial class MadechangesintotheUserTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserName",
                schema: "CM",
                table: "Games");

            migrationBuilder.CreateTable(
                name: "GameBoard",
                schema: "CM",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GameId = table.Column<int>(nullable: false),
                    Height = table.Column<int>(nullable: false),
                    Width = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameBoard", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ImageAsset",
                schema: "CM",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    AssetURI = table.Column<string>(nullable: false),
                    DateTimeCreated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageAsset", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "GameBoardItem",
                schema: "CM",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GameBoardId = table.Column<int>(nullable: false),
                    ImageAssetId = table.Column<int>(nullable: false),
                    IsToken = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    PixelHeight = table.Column<int>(nullable: false),
                    PixelWidth = table.Column<int>(nullable: false),
                    XPosition = table.Column<int>(nullable: false),
                    YPosition = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameBoardItem", x => x.ID);
                    table.ForeignKey(
                        name: "FK_GameBoardItem_GameBoard_GameBoardId",
                        column: x => x.GameBoardId,
                        principalSchema: "CM",
                        principalTable: "GameBoard",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameBoardItem_ImageAsset_ImageAssetId",
                        column: x => x.ImageAssetId,
                        principalSchema: "CM",
                        principalTable: "ImageAsset",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GameBoardItem_GameBoardId",
                schema: "CM",
                table: "GameBoardItem",
                column: "GameBoardId");

            migrationBuilder.CreateIndex(
                name: "IX_GameBoardItem_ImageAssetId",
                schema: "CM",
                table: "GameBoardItem",
                column: "ImageAssetId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameBoardItem",
                schema: "CM");

            migrationBuilder.DropTable(
                name: "GameBoard",
                schema: "CM");

            migrationBuilder.DropTable(
                name: "ImageAsset",
                schema: "CM");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                schema: "CM",
                table: "Games",
                nullable: false,
                defaultValue: "");
        }
    }
}
