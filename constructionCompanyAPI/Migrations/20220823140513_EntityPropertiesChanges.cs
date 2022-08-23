using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace constructionCompanyAPI.Migrations
{
    public partial class EntityPropertiesChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "Employees",
                newName: "Full_Name");

            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "CompanyOwners",
                newName: "Full_Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Full_Name",
                table: "Employees",
                newName: "FullName");

            migrationBuilder.RenameColumn(
                name: "Full_Name",
                table: "CompanyOwners",
                newName: "FullName");
        }
    }
}
