using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace employesControl_V2.Migrations
{
    public partial class addColumnIsLider : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isLider",
                table: "Funcionarios",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isLider",
                table: "Funcionarios");
        }
    }
}
