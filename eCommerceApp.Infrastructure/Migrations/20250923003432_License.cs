using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eCommerceApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class License : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProfessionalLicenses_Professionals_ProfessionalId",
                table: "ProfessionalLicenses");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceOfferings_Professionals_ProfessionalId",
                table: "ServiceOfferings");

            migrationBuilder.DropIndex(
                name: "IX_ProfessionalLicenses_ProfessionalId",
                table: "ProfessionalLicenses");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "CUSTUMER");

            migrationBuilder.AddColumn<Guid>(
                name: "CategoryId",
                table: "ProfessionalLicenses",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "CUSTOMER", null, "Customer", "CUSTOMER" });

            migrationBuilder.CreateIndex(
                name: "IX_ProfessionalLicenses_CategoryId",
                table: "ProfessionalLicenses",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfessionalLicenses_CategoryId_ProfessionalId",
                table: "ProfessionalLicenses",
                columns: new[] { "CategoryId", "ProfessionalId" });

            migrationBuilder.CreateIndex(
                name: "IX_ProfessionalLicenses_ProfessionalId_CategoryId_Number",
                table: "ProfessionalLicenses",
                columns: new[] { "ProfessionalId", "CategoryId", "Number" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfessionalLicenses_Categories_CategoryId",
                table: "ProfessionalLicenses",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfessionalLicenses_ProfessionalCategories_CategoryId_ProfessionalId",
                table: "ProfessionalLicenses",
                columns: new[] { "CategoryId", "ProfessionalId" },
                principalTable: "ProfessionalCategories",
                principalColumns: new[] { "CategoryId", "ProfessionalId" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfessionalLicenses_Professionals_ProfessionalId",
                table: "ProfessionalLicenses",
                column: "ProfessionalId",
                principalTable: "Professionals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceOfferings_Professionals_ProfessionalId",
                table: "ServiceOfferings",
                column: "ProfessionalId",
                principalTable: "Professionals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProfessionalLicenses_Categories_CategoryId",
                table: "ProfessionalLicenses");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfessionalLicenses_ProfessionalCategories_CategoryId_ProfessionalId",
                table: "ProfessionalLicenses");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfessionalLicenses_Professionals_ProfessionalId",
                table: "ProfessionalLicenses");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceOfferings_Professionals_ProfessionalId",
                table: "ServiceOfferings");

            migrationBuilder.DropIndex(
                name: "IX_ProfessionalLicenses_CategoryId",
                table: "ProfessionalLicenses");

            migrationBuilder.DropIndex(
                name: "IX_ProfessionalLicenses_CategoryId_ProfessionalId",
                table: "ProfessionalLicenses");

            migrationBuilder.DropIndex(
                name: "IX_ProfessionalLicenses_ProfessionalId_CategoryId_Number",
                table: "ProfessionalLicenses");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "CUSTOMER");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "ProfessionalLicenses");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "CUSTUMER", null, "Custumer", "CUSTUMER" });

            migrationBuilder.CreateIndex(
                name: "IX_ProfessionalLicenses_ProfessionalId",
                table: "ProfessionalLicenses",
                column: "ProfessionalId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProfessionalLicenses_Professionals_ProfessionalId",
                table: "ProfessionalLicenses",
                column: "ProfessionalId",
                principalTable: "Professionals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceOfferings_Professionals_ProfessionalId",
                table: "ServiceOfferings",
                column: "ProfessionalId",
                principalTable: "Professionals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
