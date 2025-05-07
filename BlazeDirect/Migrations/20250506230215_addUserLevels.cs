using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazeDirect.Migrations
{
    /// <inheritdoc />
    public partial class addUserLevels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PersonID",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserLevelID",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PersonID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UserLevelID",
                table: "AspNetUsers");
        }
    }
}
