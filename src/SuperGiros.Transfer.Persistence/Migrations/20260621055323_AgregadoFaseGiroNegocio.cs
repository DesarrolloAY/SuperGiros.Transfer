using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SuperGiros.Transfer.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AgregadoFaseGiroNegocio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Fase",
                table: "Transactions",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Fase",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Fase",
                value: 1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Fase",
                table: "Transactions");
        }
    }
}
