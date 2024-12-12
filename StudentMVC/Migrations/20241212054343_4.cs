using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentMVC.Migrations
{
    /// <inheritdoc />
    public partial class _4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Addresses_AID",
                table: "Students");

            migrationBuilder.RenameColumn(
                name: "AID",
                table: "Students",
                newName: "AId");

            migrationBuilder.RenameIndex(
                name: "IX_Students_AID",
                table: "Students",
                newName: "IX_Students_AId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Addresses_AId",
                table: "Students",
                column: "AId",
                principalTable: "Addresses",
                principalColumn: "AId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Addresses_AId",
                table: "Students");

            migrationBuilder.RenameColumn(
                name: "AId",
                table: "Students",
                newName: "AID");

            migrationBuilder.RenameIndex(
                name: "IX_Students_AId",
                table: "Students",
                newName: "IX_Students_AID");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Addresses_AID",
                table: "Students",
                column: "AID",
                principalTable: "Addresses",
                principalColumn: "AId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
