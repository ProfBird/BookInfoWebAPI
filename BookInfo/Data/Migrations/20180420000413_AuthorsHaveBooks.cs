using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BookInfo.Data.Migrations
{
    public partial class AuthorsHaveBooks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Authors_Books_BookID",
                table: "Authors");

            migrationBuilder.DropIndex(
                name: "IX_Authors_BookID",
                table: "Authors");

            migrationBuilder.DropColumn(
                name: "BookID",
                table: "Authors");

            migrationBuilder.AddColumn<int>(
                name: "AuthorID",
                table: "Books",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorID",
                table: "Books",
                column: "AuthorID");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Authors_AuthorID",
                table: "Books",
                column: "AuthorID",
                principalTable: "Authors",
                principalColumn: "AuthorID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Authors_AuthorID",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_AuthorID",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "AuthorID",
                table: "Books");

            migrationBuilder.AddColumn<int>(
                name: "BookID",
                table: "Authors",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Authors_BookID",
                table: "Authors",
                column: "BookID");

            migrationBuilder.AddForeignKey(
                name: "FK_Authors_Books_BookID",
                table: "Authors",
                column: "BookID",
                principalTable: "Books",
                principalColumn: "BookID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
