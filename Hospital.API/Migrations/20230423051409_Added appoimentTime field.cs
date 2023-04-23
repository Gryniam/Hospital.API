using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital.API.Migrations
{
    /// <inheritdoc />
    public partial class AddedappoimentTimefield : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_appoimentTable_doctorId",
                table: "appoimentTable",
                column: "doctorId");

            migrationBuilder.AddForeignKey(
                name: "FK_appoimentTable_doctorTable_doctorId",
                table: "appoimentTable",
                column: "doctorId",
                principalTable: "doctorTable",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_appoimentTable_doctorTable_doctorId",
                table: "appoimentTable");

            migrationBuilder.DropIndex(
                name: "IX_appoimentTable_doctorId",
                table: "appoimentTable");
        }
    }
}
