using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CrudVeiculos.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aluno",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    Cpf = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Telefone = table.Column<string>(type: "text", nullable: false),
                    Matricula = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aluno", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Disciplina",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    Codigo = table.Column<string>(type: "text", nullable: false),
                    Descricao = table.Column<string>(type: "text", nullable: false),
                    Objetivos = table.Column<string>(type: "text", nullable: false),
                    Conteudo = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disciplina", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Servidor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    Cpf = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Senha = table.Column<string>(type: "text", nullable: false),
                    Tipo = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servidor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CorpoDocente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DisciplinaId = table.Column<int>(type: "integer", nullable: false),
                    ServidorId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CorpoDocente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CorpoDocente_Disciplina_DisciplinaId",
                        column: x => x.DisciplinaId,
                        principalTable: "Disciplina",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CorpoDocente_Servidor_ServidorId",
                        column: x => x.ServidorId,
                        principalTable: "Servidor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tcc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AlunoId = table.Column<int>(type: "integer", nullable: false),
                    TituloProvisorio = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Resumo = table.Column<string>(type: "text", nullable: false),
                    AreaTematica = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: false),
                    OrientadorId = table.Column<int>(type: "integer", nullable: false),
                    CoorientadorId = table.Column<int>(type: "integer", nullable: true),
                    ArquivoProposta = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Periodo = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    DataPrevistaDefesa = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    DataSubmissao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DataAprovacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Observacoes = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tcc", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tcc_Aluno_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Aluno",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tcc_Servidor_CoorientadorId",
                        column: x => x.CoorientadorId,
                        principalTable: "Servidor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tcc_Servidor_OrientadorId",
                        column: x => x.OrientadorId,
                        principalTable: "Servidor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CorpoDocente_DisciplinaId",
                table: "CorpoDocente",
                column: "DisciplinaId");

            migrationBuilder.CreateIndex(
                name: "IX_CorpoDocente_ServidorId",
                table: "CorpoDocente",
                column: "ServidorId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tcc_AlunoId",
                table: "Tcc",
                column: "AlunoId");

            migrationBuilder.CreateIndex(
                name: "IX_Tcc_CoorientadorId",
                table: "Tcc",
                column: "CoorientadorId");

            migrationBuilder.CreateIndex(
                name: "IX_Tcc_OrientadorId",
                table: "Tcc",
                column: "OrientadorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CorpoDocente");

            migrationBuilder.DropTable(
                name: "Tcc");

            migrationBuilder.DropTable(
                name: "Disciplina");

            migrationBuilder.DropTable(
                name: "Aluno");

            migrationBuilder.DropTable(
                name: "Servidor");
        }
    }
}
