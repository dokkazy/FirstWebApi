using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FirstWebApi.Migrations
{
    /// <inheritdoc />
    public partial class ModifyRefreshToken : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AccessToken",
                table: "RefreshTokens",
                newName: "JwtId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "JwtId",
                table: "RefreshTokens",
                newName: "AccessToken");
        }
    }
}
