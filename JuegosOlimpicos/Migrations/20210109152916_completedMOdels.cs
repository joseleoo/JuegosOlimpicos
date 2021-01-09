using Microsoft.EntityFrameworkCore.Migrations;

namespace JuegosOlimpicos.Migrations
{
    public partial class completedMOdels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TipoPrueba",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoPrueba", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Registros",
                columns: table => new
                {
                    DeportistaId = table.Column<int>(nullable: false),
                    TipoPruebaId = table.Column<int>(nullable: false),
                    Peso = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registros", x => new { x.DeportistaId, x.TipoPruebaId });
                    table.ForeignKey(
                        name: "FK_Registros_Deportistas_DeportistaId",
                        column: x => x.DeportistaId,
                        principalTable: "Deportistas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Registros_TipoPrueba_TipoPruebaId",
                        column: x => x.TipoPruebaId,
                        principalTable: "TipoPrueba",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TipoPrueba",
                columns: new[] { "Id", "Descripcion" },
                values: new object[] { 1, "ARRANQUE" });

            migrationBuilder.InsertData(
                table: "TipoPrueba",
                columns: new[] { "Id", "Descripcion" },
                values: new object[] { 2, "ENVION" });

            migrationBuilder.CreateIndex(
                name: "IX_Registros_TipoPruebaId",
                table: "Registros",
                column: "TipoPruebaId");

            migrationBuilder.CreateIndex(
                name: "IX_Registros_DeportistaId_TipoPruebaId",
                table: "Registros",
                columns: new[] { "DeportistaId", "TipoPruebaId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Registros");

            migrationBuilder.DropTable(
                name: "TipoPrueba");
        }
    }
}
