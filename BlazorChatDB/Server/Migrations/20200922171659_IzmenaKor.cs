using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorChatDB.Server.Migrations
{
    public partial class IzmenaKor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "UclanioSe",
                table: "Korisniks",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UclanioSe",
                table: "Korisniks");
        }
    }
}
