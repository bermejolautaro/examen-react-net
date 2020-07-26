using Microsoft.EntityFrameworkCore.Migrations;

namespace ExamenReactNet.Data.Migrations
{
    public partial class SeedCarsAndBrands : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO [Brands] (Name) VALUES ('Fiat')");
            migrationBuilder.Sql("INSERT INTO [Brands] (Name) VALUES ('Peugeot')");
            migrationBuilder.Sql("INSERT INTO [Brands] (Name) VALUES ('Audi')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
