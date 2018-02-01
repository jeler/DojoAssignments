using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace wedding_planner.Migrations
{
    public partial class Initial_Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    email = table.Column<string>(nullable: true),
                    first_name = table.Column<string>(nullable: true),
                    last_name = table.Column<string>(nullable: true),
                    password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Weddings",
                columns: table => new
                {
                    WeddingId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    CreatorId = table.Column<int>(nullable: false),
                    address = table.Column<string>(nullable: false),
                    date = table.Column<DateTime>(nullable: false),
                    wedder_one = table.Column<string>(nullable: false),
                    wedder_two = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weddings", x => x.WeddingId);
                    table.ForeignKey(
                        name: "FK_Weddings_Users_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RSVPS",
                columns: table => new
                {
                    RSVPId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    UserId = table.Column<int>(nullable: false),
                    WeddingId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RSVPS", x => x.RSVPId);
                    table.ForeignKey(
                        name: "FK_RSVPS_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RSVPS_Weddings_WeddingId",
                        column: x => x.WeddingId,
                        principalTable: "Weddings",
                        principalColumn: "WeddingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RSVPS_UserId",
                table: "RSVPS",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RSVPS_WeddingId",
                table: "RSVPS",
                column: "WeddingId");

            migrationBuilder.CreateIndex(
                name: "IX_Weddings_CreatorId",
                table: "Weddings",
                column: "CreatorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RSVPS");

            migrationBuilder.DropTable(
                name: "Weddings");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
