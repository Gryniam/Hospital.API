using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital.API.Migrations
{
    /// <inheritdoc />
    public partial class Namingchanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "patiendId",
                table: "caseTable",
                newName: "patiendtId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "patiendtId",
                table: "caseTable",
                newName: "patiendId");
        }
    }
}
