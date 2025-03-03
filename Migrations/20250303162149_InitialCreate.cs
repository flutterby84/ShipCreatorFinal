using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShipCreator1.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ship",
                columns: table => new
                {
                    ShipID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ShipName = table.Column<string>(type: "TEXT", nullable: false),
                    ShipType = table.Column<string>(type: "TEXT", nullable: false),
                    NauticalMilage = table.Column<int>(type: "INTEGER", nullable: false),
                    PledgedFaction = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ship", x => x.ShipID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ship");
        }
    }
}
