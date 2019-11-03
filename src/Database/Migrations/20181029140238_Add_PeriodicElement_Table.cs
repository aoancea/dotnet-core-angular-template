using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NetCoreAngular.Database.Migrations
{
    public partial class Add_PeriodicElement_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PeriodicElement",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Position = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Weight = table.Column<decimal>(nullable: false),
                    Symbol = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeriodicElement", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PeriodicElement");
        }
    }
}
