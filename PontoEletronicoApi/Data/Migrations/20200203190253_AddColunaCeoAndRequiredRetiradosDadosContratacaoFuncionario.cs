using Microsoft.EntityFrameworkCore.Migrations;

namespace PontoEletronicoApi.Migrations
{
    public partial class AddColunaCeoAndRequiredRetiradosDadosContratacaoFuncionario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Cargo",
                table: "DadosContratacaoFuncionarios",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<bool>(
                name: "Ceo",
                table: "DadosContratacaoFuncionarios",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ceo",
                table: "DadosContratacaoFuncionarios");

            migrationBuilder.AlterColumn<string>(
                name: "Cargo",
                table: "DadosContratacaoFuncionarios",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
