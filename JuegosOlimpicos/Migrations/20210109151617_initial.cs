using Microsoft.EntityFrameworkCore.Migrations;

namespace JuegosOlimpicos.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Paises",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paises", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Deportistas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(maxLength: 50, nullable: false),
                    PaisId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deportistas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Deportistas_Paises_PaisId",
                        column: x => x.PaisId,
                        principalTable: "Paises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Descripcion" },
                values: new object[,]
                {
                    { 1, "AUS" },
                    { 2, "CHN" },
                    { 3, "FRA" },
                    { 4, "ALE" }
                });

            migrationBuilder.InsertData(
                table: "Deportistas",
                columns: new[] { "Id", "Nombre", "PaisId" },
                values: new object[,]
                {
                    { 1, "Carlos Alviz", 1 },
                    { 2, "Andres Sabogal", 2 },
                    { 3, "Jorge Ortega", 3 },
                    { 4, "Pablo Velasco", 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Deportistas_PaisId",
                table: "Deportistas",
                column: "PaisId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Deportistas");

            migrationBuilder.DropTable(
                name: "Paises");
        }
    }
}
