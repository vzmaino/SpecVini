using Microsoft.EntityFrameworkCore.Migrations;

namespace SpecVini.Migrations
{
    public partial class deletarCliente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sexo",
                table: "Clientes");

            migrationBuilder.AddColumn<bool>(
                name: "Deletado",
                table: "Clientes",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Deletado",
                table: "Clientes");

            migrationBuilder.AddColumn<int>(
                name: "Sexo",
                table: "Clientes",
                nullable: false,
                defaultValue: 0);
        }
    }
}
