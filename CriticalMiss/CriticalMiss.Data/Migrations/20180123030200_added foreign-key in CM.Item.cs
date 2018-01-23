using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CriticalMiss.Data.Migrations
{
    public partial class addedforeignkeyinCMItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Items_BoardId",
                schema: "CM",
                table: "Items",
                column: "BoardId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Boards_BoardId",
                schema: "CM",
                table: "Items",
                column: "BoardId",
                principalSchema: "CM",
                principalTable: "Boards",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Boards_BoardId",
                schema: "CM",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_BoardId",
                schema: "CM",
                table: "Items");
        }
    }
}
