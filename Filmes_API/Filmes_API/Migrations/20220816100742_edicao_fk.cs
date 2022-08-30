using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Filmes_API.Migrations
{
    public partial class edicao_fk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Filme_Diretor_diretor_id",
                table: "Filme");

            migrationBuilder.DropForeignKey(
                name: "FK_Filme_Genero_genero_id",
                table: "Filme");

            migrationBuilder.RenameColumn(
                name: "genero_id",
                table: "Filme",
                newName: "GeneroRefId");

            migrationBuilder.RenameColumn(
                name: "diretor_id",
                table: "Filme",
                newName: "DiretorRefId");

            migrationBuilder.RenameIndex(
                name: "IX_Filme_genero_id",
                table: "Filme",
                newName: "IX_Filme_GeneroRefId");

            migrationBuilder.RenameIndex(
                name: "IX_Filme_diretor_id",
                table: "Filme",
                newName: "IX_Filme_DiretorRefId");

            migrationBuilder.AddForeignKey(
                name: "FK_Filme_Diretor_DiretorRefId",
                table: "Filme",
                column: "DiretorRefId",
                principalTable: "Diretor",
                principalColumn: "Id_diretor",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Filme_Genero_GeneroRefId",
                table: "Filme",
                column: "GeneroRefId",
                principalTable: "Genero",
                principalColumn: "Id_genero",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Filme_Diretor_DiretorRefId",
                table: "Filme");

            migrationBuilder.DropForeignKey(
                name: "FK_Filme_Genero_GeneroRefId",
                table: "Filme");

            migrationBuilder.RenameColumn(
                name: "GeneroRefId",
                table: "Filme",
                newName: "genero_id");

            migrationBuilder.RenameColumn(
                name: "DiretorRefId",
                table: "Filme",
                newName: "diretor_id");

            migrationBuilder.RenameIndex(
                name: "IX_Filme_GeneroRefId",
                table: "Filme",
                newName: "IX_Filme_genero_id");

            migrationBuilder.RenameIndex(
                name: "IX_Filme_DiretorRefId",
                table: "Filme",
                newName: "IX_Filme_diretor_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Filme_Diretor_diretor_id",
                table: "Filme",
                column: "diretor_id",
                principalTable: "Diretor",
                principalColumn: "Id_diretor",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Filme_Genero_genero_id",
                table: "Filme",
                column: "genero_id",
                principalTable: "Genero",
                principalColumn: "Id_genero",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
