using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Filmes_API.Migrations
{
    public partial class CriacaoInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Diretor",
                columns: table => new
                {
                    Id_diretor = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome_diretor = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diretor", x => x.Id_diretor);
                });

            migrationBuilder.CreateTable(
                name: "Genero",
                columns: table => new
                {
                    Id_genero = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    genero = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genero", x => x.Id_genero);
                });

            migrationBuilder.CreateTable(
                name: "Filme",
                columns: table => new
                {
                    Id_filme = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    genero_id = table.Column<int>(type: "integer", nullable: false),
                    diretor_id = table.Column<int>(type: "integer", nullable: false),
                    nota = table.Column<float>(type: "real", nullable: false),
                    titulo = table.Column<string>(type: "text", nullable: false),
                    ano = table.Column<int>(type: "integer", nullable: false),
                    duracao = table.Column<int>(type: "integer", nullable: false),
                    sinopse = table.Column<string>(type: "text", nullable: false),
                    classif_indicativa = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filme", x => x.Id_filme);
                    table.ForeignKey(
                        name: "FK_Filme_Diretor_diretor_id",
                        column: x => x.diretor_id,
                        principalTable: "Diretor",
                        principalColumn: "Id_diretor",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Filme_Genero_genero_id",
                        column: x => x.genero_id,
                        principalTable: "Genero",
                        principalColumn: "Id_genero",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Filme_diretor_id",
                table: "Filme",
                column: "diretor_id");

            migrationBuilder.CreateIndex(
                name: "IX_Filme_genero_id",
                table: "Filme",
                column: "genero_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Filme");

            migrationBuilder.DropTable(
                name: "Diretor");

            migrationBuilder.DropTable(
                name: "Genero");
        }
    }
}
