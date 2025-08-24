using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITM_College.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Achievements",
                table: "Faculties",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Faculties",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Faculties",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SocialLink",
                table: "Faculties",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Facility",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Departments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Achievements",
                table: "Faculties");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Faculties");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Faculties");

            migrationBuilder.DropColumn(
                name: "SocialLink",
                table: "Faculties");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Facility");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Courses");
        }
    }
}
