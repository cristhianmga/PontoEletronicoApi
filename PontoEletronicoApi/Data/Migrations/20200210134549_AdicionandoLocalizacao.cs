using Microsoft.EntityFrameworkCore.Migrations;

namespace PontoEletronicoApi.Migrations
{
    public partial class AdicionandoLocalizacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Localizacao",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Latitude = table.Column<string>(nullable: false),
                    Longitude = table.Column<string>(nullable: false),
                    Endereco = table.Column<string>(nullable: false),
                    EmpresaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Localizacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Localizacao_Empresa_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Localizacao_EmpresaId",
                table: "Localizacao",
                column: "EmpresaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Localizacao");
        }
    }
}
