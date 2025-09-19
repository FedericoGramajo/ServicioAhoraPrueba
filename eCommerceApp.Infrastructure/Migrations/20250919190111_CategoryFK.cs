using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eCommerceApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CategoryFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ServiceOfferings_ProfessionalId",
                table: "ServiceOfferings");

            migrationBuilder.AddColumn<Guid>(
                name: "CategoryId",
                table: "ServiceOfferings",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_ServiceOfferings_CategoryId",
                table: "ServiceOfferings",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceOfferings_CategoryId_ProfessionalId",
                table: "ServiceOfferings",
                columns: new[] { "CategoryId", "ProfessionalId" });

            migrationBuilder.CreateIndex(
                name: "IX_ServiceOfferings_ProfessionalId_CategoryId",
                table: "ServiceOfferings",
                columns: new[] { "ProfessionalId", "CategoryId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceOfferings_Categories_CategoryId",
                table: "ServiceOfferings",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceOfferings_ProfessionalCategories_CategoryId_ProfessionalId",
                table: "ServiceOfferings",
                columns: new[] { "CategoryId", "ProfessionalId" },
                principalTable: "ProfessionalCategories",
                principalColumns: new[] { "CategoryId", "ProfessionalId" },
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceOfferings_Categories_CategoryId",
                table: "ServiceOfferings");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceOfferings_ProfessionalCategories_CategoryId_ProfessionalId",
                table: "ServiceOfferings");

            migrationBuilder.DropIndex(
                name: "IX_ServiceOfferings_CategoryId",
                table: "ServiceOfferings");

            migrationBuilder.DropIndex(
                name: "IX_ServiceOfferings_CategoryId_ProfessionalId",
                table: "ServiceOfferings");

            migrationBuilder.DropIndex(
                name: "IX_ServiceOfferings_ProfessionalId_CategoryId",
                table: "ServiceOfferings");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "ServiceOfferings");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceOfferings_ProfessionalId",
                table: "ServiceOfferings",
                column: "ProfessionalId");
        }
    }
}
