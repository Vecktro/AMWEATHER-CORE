using Microsoft.EntityFrameworkCore.Migrations;

namespace AMWEATHER_CORE.Migrations
{
    public partial class weatherauditory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(500)", nullable: false),
                    Apellido = table.Column<string>(type: "varchar(500)", nullable: false),
                    Password = table.Column<string>(type: "varchar(500)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Email);
                });

            migrationBuilder.CreateTable(
                name: "WeatherAuditory",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "varchar(500)", nullable: false),
                    CountryCode = table.Column<string>(type: "varchar(500)", nullable: false),
                    CityCode = table.Column<string>(type: "varchar(500)", nullable: false),
                    Temperature = table.Column<string>(type: "varchar(500)", nullable: false),
                    Day = table.Column<string>(type: "varchar(500)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeatherAuditory", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "WeatherAuditory");
        }
    }
}
