using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PontoEletronicoApi.Migrations
{
    public partial class AjusteColunaHorariosRegistroPontoEAddColunaData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<TimeSpan>(
                name: "HoraSaida",
                table: "RegistroPonto",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "HoraEntrada",
                table: "RegistroPonto",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<DateTime>(
                name: "Data",
                table: "RegistroPonto",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Data",
                table: "RegistroPonto");

            migrationBuilder.AlterColumn<DateTime>(
                name: "HoraSaida",
                table: "RegistroPonto",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(TimeSpan));

            migrationBuilder.AlterColumn<DateTime>(
                name: "HoraEntrada",
                table: "RegistroPonto",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(TimeSpan));
        }
    }
}
