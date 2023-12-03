using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemovingFuncionarioIDeVagaIDfromEscalas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FuncionarioId",
                table: "Escalas");

            migrationBuilder.DropColumn(
                name: "VagaId",
                table: "Escalas");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "FuncionarioId",
                table: "Escalas",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "VagaId",
                table: "Escalas",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
