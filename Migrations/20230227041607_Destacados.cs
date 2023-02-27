using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Yucom.Migrations
{
    /// <inheritdoc />
    public partial class Destacados : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "destacados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdEvento = table.Column<int>(type: "int", nullable: false),
                    eventoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_destacados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_destacados_Eventos_eventoId",
                        column: x => x.eventoId,
                        principalTable: "Eventos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_destacados_eventoId",
                table: "destacados",
                column: "eventoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "destacados");
        }
    }
}
