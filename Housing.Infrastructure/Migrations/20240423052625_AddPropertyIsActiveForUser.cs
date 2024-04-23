using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Housing.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddPropertyIsActiveForUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAvtive",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAvtive",
                table: "Users");
        }
    }
}
