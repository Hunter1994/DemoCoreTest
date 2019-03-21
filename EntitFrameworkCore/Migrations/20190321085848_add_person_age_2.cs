using Microsoft.EntityFrameworkCore.Migrations;

namespace Demo.EntitFrameworkCore.Migrations
{
    public partial class add_person_age_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Num",
                table: "People",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Num",
                table: "People");
        }
    }
}
