using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NetCore21Angular.Database.Migrations
{
    public partial class Add_Column_PeriodicElementID_To_Isotope_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PeriodicElementID",
                table: "Isotopes",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PeriodicElementID",
                table: "Isotopes");
        }
    }
}
