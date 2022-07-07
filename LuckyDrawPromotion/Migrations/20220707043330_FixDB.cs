using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LuckyDrawPromotion.Migrations
{
    public partial class FixDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Code_Rule_IdRule",
                table: "Code");

            migrationBuilder.DropIndex(
                name: "IX_Code_IdRule",
                table: "Code");

            migrationBuilder.DropColumn(
                name: "IdRule",
                table: "Code");

            migrationBuilder.AddColumn<Guid>(
                name: "IdGift",
                table: "Rule",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "RuleId",
                table: "Code",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmailAdmin",
                table: "Campaign",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "IdSetting",
                table: "Campaign",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Rule_IdGift",
                table: "Rule",
                column: "IdGift");

            migrationBuilder.CreateIndex(
                name: "IX_Code_RuleId",
                table: "Code",
                column: "RuleId");

            migrationBuilder.CreateIndex(
                name: "IX_Campaign_EmailAdmin",
                table: "Campaign",
                column: "EmailAdmin");

            migrationBuilder.CreateIndex(
                name: "IX_Campaign_IdSetting",
                table: "Campaign",
                column: "IdSetting",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Campaign_Admin_EmailAdmin",
                table: "Campaign",
                column: "EmailAdmin",
                principalTable: "Admin",
                principalColumn: "Email",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Campaign_Setting_IdSetting",
                table: "Campaign",
                column: "IdSetting",
                principalTable: "Setting",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Code_Rule_RuleId",
                table: "Code",
                column: "RuleId",
                principalTable: "Rule",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Rule_Gift_IdGift",
                table: "Rule",
                column: "IdGift",
                principalTable: "Gift",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Campaign_Admin_EmailAdmin",
                table: "Campaign");

            migrationBuilder.DropForeignKey(
                name: "FK_Campaign_Setting_IdSetting",
                table: "Campaign");

            migrationBuilder.DropForeignKey(
                name: "FK_Code_Rule_RuleId",
                table: "Code");

            migrationBuilder.DropForeignKey(
                name: "FK_Rule_Gift_IdGift",
                table: "Rule");

            migrationBuilder.DropIndex(
                name: "IX_Rule_IdGift",
                table: "Rule");

            migrationBuilder.DropIndex(
                name: "IX_Code_RuleId",
                table: "Code");

            migrationBuilder.DropIndex(
                name: "IX_Campaign_EmailAdmin",
                table: "Campaign");

            migrationBuilder.DropIndex(
                name: "IX_Campaign_IdSetting",
                table: "Campaign");

            migrationBuilder.DropColumn(
                name: "IdGift",
                table: "Rule");

            migrationBuilder.DropColumn(
                name: "RuleId",
                table: "Code");

            migrationBuilder.DropColumn(
                name: "EmailAdmin",
                table: "Campaign");

            migrationBuilder.DropColumn(
                name: "IdSetting",
                table: "Campaign");

            migrationBuilder.AddColumn<Guid>(
                name: "IdRule",
                table: "Code",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Code_IdRule",
                table: "Code",
                column: "IdRule");

            migrationBuilder.AddForeignKey(
                name: "FK_Code_Rule_IdRule",
                table: "Code",
                column: "IdRule",
                principalTable: "Rule",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
