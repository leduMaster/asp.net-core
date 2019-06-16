using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFDataAccess.Migrations
{
    public partial class Update_3_Dodate_Slike : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "PostPicture");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "PostPicture");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "PostPicture");

            migrationBuilder.DropColumn(
                name: "ModifidedAt",
                table: "PostPicture");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "PostPicture",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "PostPicture",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "PostPicture",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifidedAt",
                table: "PostPicture",
                nullable: true);
        }
    }
}
