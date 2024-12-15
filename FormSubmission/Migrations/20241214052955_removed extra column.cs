using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FormSubmission.Migrations
{
    /// <inheritdoc />
    public partial class removedextracolumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MajorId",
                table: "students");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MajorId",
                table: "students",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
