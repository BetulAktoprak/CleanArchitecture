using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchitecture.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class mg7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
        name: "RefreshToken",
        table: "Users",
        type: "nvarchar(max)",
        nullable: true,
        oldClrType: typeof(string),
        oldType: "nvarchar(max)",
        oldNullable: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
        name: "RefreshToken",
        table: "Users",
        type: "nvarchar(max)",
        nullable: false,
        oldClrType: typeof(string),
        oldType: "nvarchar(max)",
        oldNullable: true);
        }
    }
}
