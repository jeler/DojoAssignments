using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace bank_accounts.Migrations
{
    public partial class Second_Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "balance",
                table: "users",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "balance",
                table: "users");
        }
    }
}
