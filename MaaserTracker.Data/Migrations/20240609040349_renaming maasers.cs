using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MaaserTracker.Data.Migrations
{
    /// <inheritdoc />
    public partial class renamingmaasers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Massers",
                table: "Massers");

            migrationBuilder.RenameTable(
                name: "Massers",
                newName: "Maasers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Maasers",
                table: "Maasers",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Maasers",
                table: "Maasers");

            migrationBuilder.RenameTable(
                name: "Maasers",
                newName: "Massers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Massers",
                table: "Massers",
                column: "Id");
        }
    }
}
