using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CriticalMiss.Data.Migrations
{
    public partial class AfterResolvedconflictwithmultipleclass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "CM");

            migrationBuilder.CreateTable(
                name: "Games",
                schema: "CM",
                columns: table => new
                {
                    GameId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GameName = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.GameId);
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
                name: "Boards",
                schema: "CM",
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
                    table.PrimaryKey("PK_Boards", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Boards_Games_GameId",
                        column: x => x.GameId,
                        principalSchema: "CM",
                        principalTable: "Games",
                        principalColumn: "GameId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                schema: "CM",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BoardId = table.Column<int>(nullable: false),
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
                    table.PrimaryKey("PK_Items", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Items_ImageAsset_ImageAssetId",
                        column: x => x.ImageAssetId,
                        principalSchema: "CM",
                        principalTable: "ImageAsset",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Boards_GameId",
                schema: "CM",
                table: "Boards",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_ImageAssetId",
                schema: "CM",
                table: "Items",
                column: "ImageAssetId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Boards",
                schema: "CM");

            migrationBuilder.DropTable(
                name: "Items",
                schema: "CM");

            migrationBuilder.DropTable(
                name: "Games",
                schema: "CM");

            migrationBuilder.DropTable(
                name: "ImageAsset",
                schema: "CM");
        }
    }
}
