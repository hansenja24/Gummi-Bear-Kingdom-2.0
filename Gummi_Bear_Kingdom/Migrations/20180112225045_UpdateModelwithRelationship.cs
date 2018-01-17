using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Gummi_Bear_Kingdom.Migrations
{
    public partial class UpdateModelwithRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReviewId",
                table: "Products",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Products_ReviewId",
                table: "Products",
                column: "ReviewId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Reviews_ReviewId",
                table: "Products",
                column: "ReviewId",
                principalTable: "Reviews",
                principalColumn: "ReviewId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Reviews_ReviewId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ReviewId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ReviewId",
                table: "Products");
        }
    }
}
