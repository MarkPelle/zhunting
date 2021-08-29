using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace zhunting.DataAccess.Migrations
{
    public partial class MediaCollection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Url",
                table: "Media");

            migrationBuilder.AddColumn<Guid>(
                name: "MediaID",
                table: "Image",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Image_MediaID",
                table: "Image",
                column: "MediaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Image_Media_MediaID",
                table: "Image",
                column: "MediaID",
                principalTable: "Media",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Image_Media_MediaID",
                table: "Image");

            migrationBuilder.DropIndex(
                name: "IX_Image_MediaID",
                table: "Image");

            migrationBuilder.DropColumn(
                name: "MediaID",
                table: "Image");

            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "Media",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
