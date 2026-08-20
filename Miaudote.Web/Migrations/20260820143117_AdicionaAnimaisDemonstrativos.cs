using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Miaudote.Web.Migrations
{
    /// <inheritdoc />
    public partial class AdicionaAnimaisDemonstrativos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "animais",
                columns: new[] { "id", "ativo", "castrado", "cidade_id", "data_atualizacao", "data_cadastro", "descricao", "especie_id", "genero", "idade_aproximada_meses", "nome", "nome_arquivo_imagem", "porte", "raca", "status", "vacinado" },
                values: new object[,]
                {
                    { 1, true, true, 2, null, new DateTime(2026, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Max é um cão carinhoso, brincalhão e sociável. Procura uma família responsável e preparada para oferecer atenção, cuidados e um lar seguro.", 1, "Macho", 36, "Max", "cachorro.jpg", "Grande", "Golden Retriever", "Disponivel", true },
                    { 2, true, true, 4, null, new DateTime(2026, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Luna é uma gata calma, carinhosa e independente. Procura um lar responsável, seguro e preparado para respeitar o seu período de adaptação.", 2, "Femea", 24, "Luna", "luna.jpg", "Pequeno", "Gato sem raça definida", "Disponivel", true },
                    { 3, true, false, 5, null, new DateTime(2026, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bob é um cão energético, curioso e sociável. Precisa de uma família que possa oferecer passeios, atividades e os cuidados necessários.", 1, "Macho", 48, "Bob", "bob.jpg", "Medio", "Beagle", "Disponivel", true },
                    { 4, true, true, 3, null, new DateTime(2026, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mimi é uma gata jovem, calma, curiosa e carinhosa. Procura uma família responsável que ofereça proteção, acompanhamento e carinho.", 2, "Femea", 12, "Mimi", "mimi.jpg", "Pequeno", "Siamês", "Disponivel", true }
                });

            migrationBuilder.InsertData(
                table: "animais_temperamentos",
                columns: new[] { "animal_id", "temperamento_id" },
                values: new object[,]
                {
                    { 1, 2 },
                    { 1, 3 },
                    { 1, 4 },
                    { 2, 1 },
                    { 2, 2 },
                    { 2, 6 },
                    { 3, 4 },
                    { 3, 5 },
                    { 3, 9 },
                    { 4, 1 },
                    { 4, 2 },
                    { 4, 9 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "animais_temperamentos",
                keyColumns: new[] { "animal_id", "temperamento_id" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "animais_temperamentos",
                keyColumns: new[] { "animal_id", "temperamento_id" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "animais_temperamentos",
                keyColumns: new[] { "animal_id", "temperamento_id" },
                keyValues: new object[] { 1, 4 });

            migrationBuilder.DeleteData(
                table: "animais_temperamentos",
                keyColumns: new[] { "animal_id", "temperamento_id" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "animais_temperamentos",
                keyColumns: new[] { "animal_id", "temperamento_id" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "animais_temperamentos",
                keyColumns: new[] { "animal_id", "temperamento_id" },
                keyValues: new object[] { 2, 6 });

            migrationBuilder.DeleteData(
                table: "animais_temperamentos",
                keyColumns: new[] { "animal_id", "temperamento_id" },
                keyValues: new object[] { 3, 4 });

            migrationBuilder.DeleteData(
                table: "animais_temperamentos",
                keyColumns: new[] { "animal_id", "temperamento_id" },
                keyValues: new object[] { 3, 5 });

            migrationBuilder.DeleteData(
                table: "animais_temperamentos",
                keyColumns: new[] { "animal_id", "temperamento_id" },
                keyValues: new object[] { 3, 9 });

            migrationBuilder.DeleteData(
                table: "animais_temperamentos",
                keyColumns: new[] { "animal_id", "temperamento_id" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "animais_temperamentos",
                keyColumns: new[] { "animal_id", "temperamento_id" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                table: "animais_temperamentos",
                keyColumns: new[] { "animal_id", "temperamento_id" },
                keyValues: new object[] { 4, 9 });

            migrationBuilder.DeleteData(
                table: "animais",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "animais",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "animais",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "animais",
                keyColumn: "id",
                keyValue: 4);
        }
    }
}
