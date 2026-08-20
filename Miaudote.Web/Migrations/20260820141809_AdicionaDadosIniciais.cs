using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Miaudote.Web.Migrations
{
    /// <inheritdoc />
    public partial class AdicionaDadosIniciais : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "cidades",
                columns: new[] { "id", "ativa", "nome", "uf" },
                values: new object[,]
                {
                    { 1, true, "Barra Bonita", "SP" },
                    { 2, true, "São Paulo", "SP" },
                    { 3, true, "Campinas", "SP" },
                    { 4, true, "Rio de Janeiro", "RJ" },
                    { 5, true, "Belo Horizonte", "MG" }
                });

            migrationBuilder.InsertData(
                table: "especies",
                columns: new[] { "id", "ativa", "nome" },
                values: new object[,]
                {
                    { 1, true, "Cão" },
                    { 2, true, "Gato" }
                });

            migrationBuilder.InsertData(
                table: "temperamentos",
                columns: new[] { "id", "ativo", "nome" },
                values: new object[,]
                {
                    { 1, true, "Calmo" },
                    { 2, true, "Carinhoso" },
                    { 3, true, "Brincalhão" },
                    { 4, true, "Sociável" },
                    { 5, true, "Energético" },
                    { 6, true, "Independente" },
                    { 7, true, "Obediente" },
                    { 8, true, "Protetor" },
                    { 9, true, "Curioso" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "cidades",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "cidades",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "cidades",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "cidades",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "cidades",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "especies",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "especies",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "temperamentos",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "temperamentos",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "temperamentos",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "temperamentos",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "temperamentos",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "temperamentos",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "temperamentos",
                keyColumn: "id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "temperamentos",
                keyColumn: "id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "temperamentos",
                keyColumn: "id",
                keyValue: 9);
        }
    }
}
