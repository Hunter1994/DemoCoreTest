using Microsoft.EntityFrameworkCore.Migrations;

namespace Demo.EntitFrameworkCore.Migrations
{
    public partial class add_person_age_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Age",
                table: "People",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Age",
                table: "People",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
