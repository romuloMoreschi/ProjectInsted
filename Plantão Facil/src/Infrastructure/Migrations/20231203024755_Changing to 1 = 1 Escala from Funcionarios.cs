using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Changingto11EscalafromFuncionarios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EscalaFuncionario");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_EscalaId",
                table: "Funcionarios",
                column: "EscalaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionarios_Escalas_EscalaId",
                table: "Funcionarios",
                column: "EscalaId",
                principalTable: "Escalas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Funcionarios_Escalas_EscalaId",
                table: "Funcionarios");

            migrationBuilder.DropIndex(
                name: "IX_Funcionarios_EscalaId",
                table: "Funcionarios");

            migrationBuilder.CreateTable(
                name: "EscalaFuncionario",
                columns: table => new
                {
                    EscalasId = table.Column<long>(type: "bigint", nullable: false),
                    FuncionariosId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EscalaFuncionario", x => new { x.EscalasId, x.FuncionariosId });
                    table.ForeignKey(
                        name: "FK_EscalaFuncionario_Escalas_EscalasId",
                        column: x => x.EscalasId,
                        principalTable: "Escalas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EscalaFuncionario_Funcionarios_FuncionariosId",
                        column: x => x.FuncionariosId,
                        principalTable: "Funcionarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EscalaFuncionario_FuncionariosId",
                table: "EscalaFuncionario",
                column: "FuncionariosId");
        }
    }
}
