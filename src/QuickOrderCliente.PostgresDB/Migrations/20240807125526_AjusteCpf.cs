using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuickOrderCliente.PostgresDB.Migrations
{
    public partial class AjusteCpf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Cpf",
                table: "Cliente",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cpf",
                table: "Cliente");
        }
    }
}
