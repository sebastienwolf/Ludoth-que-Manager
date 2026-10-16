using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LudothequeManager.Migrations
{
    /// <inheritdoc />
    public partial class ReplaceIsAvailableWithStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
              name: "Status",
              table: "Games",
              type: "int",
              nullable: false,
              defaultValue: 0);

            migrationBuilder.Sql(
                "UPDATE Games SET Status = CASE WHEN IsAvailable = 1 THEN 0 ELSE 1 END"
            );

            migrationBuilder.DropColumn(
                name: "IsAvailable",
                table: "Games");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
            name: "IsAvailable",
            table: "Games",
            type: "bit",
            nullable: false,
            defaultValue: false);

            migrationBuilder.Sql(
                "UPDATE Games SET IsAvailable = CASE WHEN Status = 0 THEN 1 ELSE 0 END"
            );

            migrationBuilder.DropColumn(
            name: "Status",
            table: "Games");
        }
    }
}
