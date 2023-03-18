using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital.API.Migrations
{
    /// <inheritdoc />
    public partial class Dude : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "patiendtId",
                table: "caseTable",
                newName: "patientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "patientId",
                table: "caseTable",
                newName: "patiendtId");
        }
    }
}
