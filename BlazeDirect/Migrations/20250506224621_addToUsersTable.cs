using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazeDirect.Migrations
{
    /// <inheritdoc />
    public partial class addToUsersTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropColumn(
            //    name: "BirthPlace",
            //    table: "People");

            //migrationBuilder.DropColumn(
            //    name: "DeathDate",
            //    table: "People");

            //migrationBuilder.DropColumn(
            //    name: "DeathPlace",
            //    table: "People");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BirthPlace",
                table: "People",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeathDate",
                table: "People",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeathPlace",
                table: "People",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
