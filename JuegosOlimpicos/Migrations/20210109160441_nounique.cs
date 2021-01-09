using Microsoft.EntityFrameworkCore.Migrations;

namespace JuegosOlimpicos.Migrations
{
    public partial class nounique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Registros_DeportistaId_TipoPruebaId",
                table: "Registros");

            migrationBuilder.CreateIndex(
                name: "IX_Registros_DeportistaId_TipoPruebaId",
                table: "Registros",
                columns: new[] { "DeportistaId", "TipoPruebaId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Registros_DeportistaId_TipoPruebaId",
                table: "Registros");

            migrationBuilder.CreateIndex(
                name: "IX_Registros_DeportistaId_TipoPruebaId",
                table: "Registros",
                columns: new[] { "DeportistaId", "TipoPruebaId" },
                unique: true);
        }
    }
}
