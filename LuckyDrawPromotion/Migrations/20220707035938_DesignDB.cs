using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LuckyDrawPromotion.Migrations
{
    public partial class DesignDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Fullname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.Email);
                });

            migrationBuilder.CreateTable(
                name: "Campaign",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StartedDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    ExpiredDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AutoUpdate = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    UseOnlyOnce = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campaign", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Gift",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gift", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Setting",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GenQR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LanddingPage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SMSText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DailyReport = table.Column<bool>(type: "bit", nullable: false),
                    TimeSend = table.Column<DateTime>(type: "datetime", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Setting", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    PhoneNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Fullname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DoB = table.Column<DateTime>(type: "date", nullable: false),
                    Positon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeBusiness = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Block = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.PhoneNumber);
                });

            migrationBuilder.CreateTable(
                name: "InsCode",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Charset = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Length = table.Column<int>(type: "int", nullable: false),
                    Prefix = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Postfix = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameCampaign = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsCode", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InsCode_Campaign_NameCampaign",
                        column: x => x.NameCampaign,
                        principalTable: "Campaign",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Log",
                columns: table => new
                {
                    Priority = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameCampaign = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Log", x => x.Priority);
                    table.ForeignKey(
                        name: "FK_Log_Campaign_NameCampaign",
                        column: x => x.NameCampaign,
                        principalTable: "Campaign",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rule",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Schedule = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    Probability = table.Column<int>(type: "int", nullable: false),
                    QuantityGift = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    Priority = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    NameCampaign = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rule_Campaign_NameCampaign",
                        column: x => x.NameCampaign,
                        principalTable: "Campaign",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Code",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Target = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ExpiredDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    UsedCount = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    LimitUsage = table.Column<int>(type: "int", nullable: false),
                    NameCampaign = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdGift = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdRule = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Code", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Code_Campaign_NameCampaign",
                        column: x => x.NameCampaign,
                        principalTable: "Campaign",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Code_Gift_IdGift",
                        column: x => x.IdGift,
                        principalTable: "Gift",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Code_Rule_IdRule",
                        column: x => x.IdRule,
                        principalTable: "Rule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Award",
                columns: table => new
                {
                    IdCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PhoneNumberUser = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UsedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsSent = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Award", x => new { x.IdCode, x.PhoneNumberUser });
                    table.ForeignKey(
                        name: "FK_Award_Code_IdCode",
                        column: x => x.IdCode,
                        principalTable: "Code",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Award_User_PhoneNumberUser",
                        column: x => x.PhoneNumberUser,
                        principalTable: "User",
                        principalColumn: "PhoneNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Award_PhoneNumberUser",
                table: "Award",
                column: "PhoneNumberUser");

            migrationBuilder.CreateIndex(
                name: "IX_Code_IdGift",
                table: "Code",
                column: "IdGift");

            migrationBuilder.CreateIndex(
                name: "IX_Code_IdRule",
                table: "Code",
                column: "IdRule");

            migrationBuilder.CreateIndex(
                name: "IX_Code_NameCampaign",
                table: "Code",
                column: "NameCampaign");

            migrationBuilder.CreateIndex(
                name: "IX_InsCode_NameCampaign",
                table: "InsCode",
                column: "NameCampaign");

            migrationBuilder.CreateIndex(
                name: "IX_Log_NameCampaign",
                table: "Log",
                column: "NameCampaign");

            migrationBuilder.CreateIndex(
                name: "IX_Rule_NameCampaign",
                table: "Rule",
                column: "NameCampaign");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "Award");

            migrationBuilder.DropTable(
                name: "InsCode");

            migrationBuilder.DropTable(
                name: "Log");

            migrationBuilder.DropTable(
                name: "Setting");

            migrationBuilder.DropTable(
                name: "Code");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Gift");

            migrationBuilder.DropTable(
                name: "Rule");

            migrationBuilder.DropTable(
                name: "Campaign");
        }
    }
}
