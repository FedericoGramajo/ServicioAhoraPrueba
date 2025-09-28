using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eCommerceApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class cambioCat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CategoryId1",
                table: "ServiceOfferings",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ServiceOfferings_CategoryId1",
                table: "ServiceOfferings",
                column: "CategoryId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceOfferings_Categories_CategoryId1",
                table: "ServiceOfferings",
                column: "CategoryId1",
                principalTable: "Categories",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceOfferings_Categories_CategoryId1",
                table: "ServiceOfferings");

            migrationBuilder.DropIndex(
                name: "IX_ServiceOfferings_CategoryId1",
                table: "ServiceOfferings");

            migrationBuilder.DropColumn(
                name: "CategoryId1",
                table: "ServiceOfferings");
        }
    }
}
