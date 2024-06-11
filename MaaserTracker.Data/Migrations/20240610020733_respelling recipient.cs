using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MaaserTracker.Data.Migrations
{
    /// <inheritdoc />
    public partial class respellingrecipient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Recepient",
                table: "Maasers",
                newName: "Recipient");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Recipient",
                table: "Maasers",
                newName: "Recepient");
        }
    }
}
