using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazeDirect.Migrations
{
    /// <inheritdoc />
    public partial class initCreate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Relationships_People_PersonId",
                table: "Relationships");

            migrationBuilder.DropForeignKey(
                name: "FK_Relationships_People_RelatedPersonId",
                table: "Relationships");

            migrationBuilder.AddForeignKey(
                name: "FK_Relationships_People_PersonId",
                table: "Relationships",
                column: "PersonId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction,
                onUpdate: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Relationships_People_RelatedPersonId",
                table: "Relationships",
                column: "RelatedPersonId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction,
                onUpdate: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Relationships_People_PersonId",
                table: "Relationships");

            migrationBuilder.DropForeignKey(
                name: "FK_Relationships_People_RelatedPersonId",
                table: "Relationships");

            migrationBuilder.AddForeignKey(
                name: "FK_Relationships_People_PersonId",
                table: "Relationships",
                column: "PersonId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction, onUpdate: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Relationships_People_RelatedPersonId",
                table: "Relationships",
                column: "RelatedPersonId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction, onUpdate: ReferentialAction.NoAction);
        }
    }
}
