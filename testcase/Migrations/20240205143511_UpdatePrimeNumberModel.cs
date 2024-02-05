using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace testcase.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePrimeNumberModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_primenumbers_userId",
                table: "primenumbers",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_primenumbers_userId",
                table: "primenumbers");
        }
    }
}
