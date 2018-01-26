using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace bank_accounts.Migrations
{
    public partial class Third_Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_transactions_users_Userid",
                table: "transactions");

            migrationBuilder.AlterColumn<long>(
                name: "Userid",
                table: "transactions",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                table: "transactions",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_transactions_users_Userid",
                table: "transactions",
                column: "Userid",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_transactions_users_Userid",
                table: "transactions");

            migrationBuilder.DropColumn(
                name: "created_at",
                table: "transactions");

            migrationBuilder.AlterColumn<long>(
                name: "Userid",
                table: "transactions",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddForeignKey(
                name: "FK_transactions_users_Userid",
                table: "transactions",
                column: "Userid",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
