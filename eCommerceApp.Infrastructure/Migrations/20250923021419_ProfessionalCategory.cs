using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eCommerceApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ProfessionalCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProfessionalCategories_Categories_CategoryId",
                table: "ProfessionalCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfessionalCategories_Professionals_ProfessionalId",
                table: "ProfessionalCategories");

            migrationBuilder.CreateIndex(
                name: "IX_ProfessionalCategories_CategoryId",
                table: "ProfessionalCategories",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProfessionalCategories_Categories_CategoryId",
                table: "ProfessionalCategories",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfessionalCategories_Professionals_ProfessionalId",
                table: "ProfessionalCategories",
                column: "ProfessionalId",
                principalTable: "Professionals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProfessionalCategories_Categories_CategoryId",
                table: "ProfessionalCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfessionalCategories_Professionals_ProfessionalId",
                table: "ProfessionalCategories");

            migrationBuilder.DropIndex(
                name: "IX_ProfessionalCategories_CategoryId",
                table: "ProfessionalCategories");

            migrationBuilder.AddForeignKey(
                name: "FK_ProfessionalCategories_Categories_CategoryId",
                table: "ProfessionalCategories",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfessionalCategories_Professionals_ProfessionalId",
                table: "ProfessionalCategories",
                column: "ProfessionalId",
                principalTable: "Professionals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
