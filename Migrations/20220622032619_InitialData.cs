using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace employesControl_V2.Migrations
{
    public partial class InitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Funcionarios",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    Sobrenome = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    NumeroChapa = table.Column<decimal>(type: "numeric", nullable: false),
                    LiderId = table.Column<int>(type: "integer", nullable: true),
                    Password = table.Column<string>(type: "text", nullable: false),
                    Telefones = table.Column<string[]>(type: "text[]", nullable: true),
                    DDD = table.Column<string>(type: "text", nullable: false),
                    IsLider = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionarios", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Lideres",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdFuncionario = table.Column<int>(type: "integer", nullable: true),
                    Ativo = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lideres", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "Unique_Index",
                table: "Funcionarios",
                column: "NumeroChapa",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Funcionarios");

            migrationBuilder.DropTable(
                name: "Lideres");
        }
    }
}
