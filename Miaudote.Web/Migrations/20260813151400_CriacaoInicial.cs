using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Miaudote.Web.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "cidades",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nome = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    uf = table.Column<string>(type: "varchar(2)", maxLength: 2, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ativa = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cidades", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "especies",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nome = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ativa = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_especies", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "mensagens_contato",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nome = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    email = table.Column<string>(type: "varchar(254)", maxLength: 254, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    assunto = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    mensagem = table.Column<string>(type: "varchar(2000)", maxLength: 2000, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    respondida = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    data_envio = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    data_resposta = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mensagens_contato", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "temperamentos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nome = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ativo = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_temperamentos", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "animais",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nome = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    especie_id = table.Column<int>(type: "int", nullable: false),
                    raca = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    idade_aproximada_meses = table.Column<int>(type: "int", nullable: false),
                    porte = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    genero = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    cidade_id = table.Column<int>(type: "int", nullable: false),
                    descricao = table.Column<string>(type: "varchar(3000)", maxLength: 3000, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    vacinado = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    castrado = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    nome_arquivo_imagem = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    status = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ativo = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    data_cadastro = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    data_atualizacao = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_animais", x => x.id);
                    table.ForeignKey(
                        name: "FK_animais_cidades_cidade_id",
                        column: x => x.cidade_id,
                        principalTable: "cidades",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_animais_especies_especie_id",
                        column: x => x.especie_id,
                        principalTable: "especies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "animais_temperamentos",
                columns: table => new
                {
                    animal_id = table.Column<int>(type: "int", nullable: false),
                    temperamento_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_animais_temperamentos", x => new { x.animal_id, x.temperamento_id });
                    table.ForeignKey(
                        name: "FK_animais_temperamentos_animais_animal_id",
                        column: x => x.animal_id,
                        principalTable: "animais",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_animais_temperamentos_temperamentos_temperamento_id",
                        column: x => x.temperamento_id,
                        principalTable: "temperamentos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "solicitacoes_adocao",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    animal_id = table.Column<int>(type: "int", nullable: false),
                    nome_completo = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    email = table.Column<string>(type: "varchar(254)", maxLength: 254, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    telefone = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    cidade = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    endereco = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    motivo_adocao = table.Column<string>(type: "varchar(3000)", maxLength: 3000, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    status = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    data_solicitacao = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    data_atualizacao = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    observacao_administrativa = table.Column<string>(type: "varchar(3000)", maxLength: 3000, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_solicitacoes_adocao", x => x.id);
                    table.ForeignKey(
                        name: "FK_solicitacoes_adocao_animais_animal_id",
                        column: x => x.animal_id,
                        principalTable: "animais",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_animais_cidade_id",
                table: "animais",
                column: "cidade_id");

            migrationBuilder.CreateIndex(
                name: "IX_animais_especie_id",
                table: "animais",
                column: "especie_id");

            migrationBuilder.CreateIndex(
                name: "IX_animais_status",
                table: "animais",
                column: "status");

            migrationBuilder.CreateIndex(
                name: "IX_animais_temperamentos_temperamento_id",
                table: "animais_temperamentos",
                column: "temperamento_id");

            migrationBuilder.CreateIndex(
                name: "IX_cidades_nome_uf",
                table: "cidades",
                columns: new[] { "nome", "uf" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_especies_nome",
                table: "especies",
                column: "nome",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_mensagens_contato_data_envio",
                table: "mensagens_contato",
                column: "data_envio");

            migrationBuilder.CreateIndex(
                name: "IX_mensagens_contato_respondida",
                table: "mensagens_contato",
                column: "respondida");

            migrationBuilder.CreateIndex(
                name: "IX_solicitacoes_adocao_animal_id",
                table: "solicitacoes_adocao",
                column: "animal_id");

            migrationBuilder.CreateIndex(
                name: "IX_solicitacoes_adocao_data_solicitacao",
                table: "solicitacoes_adocao",
                column: "data_solicitacao");

            migrationBuilder.CreateIndex(
                name: "IX_solicitacoes_adocao_status",
                table: "solicitacoes_adocao",
                column: "status");

            migrationBuilder.CreateIndex(
                name: "IX_temperamentos_nome",
                table: "temperamentos",
                column: "nome",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "animais_temperamentos");

            migrationBuilder.DropTable(
                name: "mensagens_contato");

            migrationBuilder.DropTable(
                name: "solicitacoes_adocao");

            migrationBuilder.DropTable(
                name: "temperamentos");

            migrationBuilder.DropTable(
                name: "animais");

            migrationBuilder.DropTable(
                name: "cidades");

            migrationBuilder.DropTable(
                name: "especies");
        }
    }
}
