using Microsoft.EntityFrameworkCore.Migrations;

namespace NetCore21Angular.Database.Migrations
{
    public partial class Rename_Table_PeriodicElement_To_PeriodicElements : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PeriodicElement",
                table: "PeriodicElement");

            migrationBuilder.RenameTable(
                name: "PeriodicElement",
                newName: "PeriodicElements");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PeriodicElements",
                table: "PeriodicElements",
                column: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PeriodicElements",
                table: "PeriodicElements");

            migrationBuilder.RenameTable(
                name: "PeriodicElements",
                newName: "PeriodicElement");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PeriodicElement",
                table: "PeriodicElement",
                column: "ID");
        }
    }
}
