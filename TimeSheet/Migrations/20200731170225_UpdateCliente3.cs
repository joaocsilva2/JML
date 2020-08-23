using Microsoft.EntityFrameworkCore.Migrations;

namespace TimeSheet.Migrations
{
    public partial class UpdateCliente3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Observações",
                table: "Clientes");

            migrationBuilder.AddColumn<string>(
                name: "Observacoes",
                table: "Clientes",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Observacoes",
                table: "Clientes");

            migrationBuilder.AddColumn<string>(
                name: "Observações",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
