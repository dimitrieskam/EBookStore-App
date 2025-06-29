using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EBookStore.Repository.Migrations
{
    /// <inheritdoc />
    public partial class changeRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Authors_Publishers_PublisherId",
                table: "Authors");

            migrationBuilder.DropIndex(
                name: "IX_Authors_PublisherId",
                table: "Authors");

            migrationBuilder.DropColumn(
                name: "PublisherId",
                table: "Authors");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PublisherId",
                table: "Authors",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Authors_PublisherId",
                table: "Authors",
                column: "PublisherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Authors_Publishers_PublisherId",
                table: "Authors",
                column: "PublisherId",
                principalTable: "Publishers",
                principalColumn: "Id");
        }
    }
}
