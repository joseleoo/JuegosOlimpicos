using Microsoft.EntityFrameworkCore.Migrations;

namespace JuegosOlimpicos.Migrations
{
    public partial class nounique2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Registros",
                table: "Registros");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Registros",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Registros",
                table: "Registros",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Registros",
                table: "Registros");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Registros");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Registros",
                table: "Registros",
                columns: new[] { "DeportistaId", "TipoPruebaId" });
        }
    }
}
