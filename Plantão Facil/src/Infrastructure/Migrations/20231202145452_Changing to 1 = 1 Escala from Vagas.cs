using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Changingto11EscalafromVagas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EscalaVaga");

            migrationBuilder.CreateIndex(
                name: "IX_Vagas_EscalaId",
                table: "Vagas",
                column: "EscalaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vagas_Escalas_EscalaId",
                table: "Vagas",
                column: "EscalaId",
                principalTable: "Escalas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vagas_Escalas_EscalaId",
                table: "Vagas");

            migrationBuilder.DropIndex(
                name: "IX_Vagas_EscalaId",
                table: "Vagas");

            migrationBuilder.CreateTable(
                name: "EscalaVaga",
                columns: table => new
                {
                    EscalasId = table.Column<long>(type: "bigint", nullable: false),
                    VagasId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EscalaVaga", x => new { x.EscalasId, x.VagasId });
                    table.ForeignKey(
                        name: "FK_EscalaVaga_Escalas_EscalasId",
                        column: x => x.EscalasId,
                        principalTable: "Escalas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EscalaVaga_Vagas_VagasId",
                        column: x => x.VagasId,
                        principalTable: "Vagas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EscalaVaga_VagasId",
                table: "EscalaVaga",
                column: "VagasId");
        }
    }
}
