using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LuckyDrawPromotion.Migrations
{
    public partial class UpdateAward : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Award",
                table: "Award");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "Award",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Award",
                table: "Award",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Award_IdCode",
                table: "Award",
                column: "IdCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Award",
                table: "Award");

            migrationBuilder.DropIndex(
                name: "IX_Award_IdCode",
                table: "Award");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Award");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Award",
                table: "Award",
                columns: new[] { "IdCode", "PhoneNumberUser" });
        }
    }
}
