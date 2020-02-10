using Microsoft.EntityFrameworkCore.Migrations;

namespace PontoEletronicoApi.Migrations
{
    public partial class ModificandoColunasLatitudeLongitudeDouble : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Longitude",
                table: "Localizacao",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<double>(
                name: "Latitude",
                table: "Localizacao",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Longitude",
                table: "Localizacao",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<string>(
                name: "Latitude",
                table: "Localizacao",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(double));
        }
    }
}
