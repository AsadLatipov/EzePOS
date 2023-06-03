using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EzePOS.Migrations
{
    /// <inheritdoc />
    public partial class qwertyaswaw : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Measure",
                table: "Products",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Measure",
                table: "Products");
        }
    }
}
