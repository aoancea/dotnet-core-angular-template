using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NetCoreAngular.Database.Migrations
{
    public partial class Add_Isotopes_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Isotopes",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    NuclideSymbol = table.Column<string>(nullable: true),
                    Z = table.Column<int>(nullable: false),
                    N = table.Column<int>(nullable: false),
                    IsotopicMass = table.Column<string>(nullable: true),
                    DecayModes = table.Column<string>(nullable: true),
                    DaughterIsotope = table.Column<string>(nullable: true),
                    NuclearSpinAndParity = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Isotopes", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Isotopes");
        }
    }
}
