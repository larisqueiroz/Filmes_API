using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Filmes_API.Migrations
{
    public partial class add_fk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Filme_Diretor_DiretorRefId",
                table: "Filme");

            migrationBuilder.DropForeignKey(
                name: "FK_Filme_Genero_GeneroRefId",
                table: "Filme");

            migrationBuilder.DropIndex(
                name: "IX_Filme_DiretorRefId",
                table: "Filme");

            migrationBuilder.DropIndex(
                name: "IX_Filme_GeneroRefId",
                table: "Filme");

            migrationBuilder.RenameColumn(
                name: "GeneroRefId",
                table: "Filme",
                newName: "Id_diretor");

            migrationBuilder.RenameColumn(
                name: "DiretorRefId",
                table: "Filme",
                newName: "Id_Genero");

            migrationBuilder.AddColumn<int>(
                name: "DiretorId_diretor",
                table: "Filme",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GeneroId_genero",
                table: "Filme",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Filme_DiretorId_diretor",
                table: "Filme",
                column: "DiretorId_diretor");

            migrationBuilder.CreateIndex(
                name: "IX_Filme_GeneroId_genero",
                table: "Filme",
                column: "GeneroId_genero");

            migrationBuilder.AddForeignKey(
                name: "FK_Filme_Diretor_DiretorId_diretor",
                table: "Filme",
                column: "DiretorId_diretor",
                principalTable: "Diretor",
                principalColumn: "Id_diretor",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Filme_Genero_GeneroId_genero",
                table: "Filme",
                column: "GeneroId_genero",
                principalTable: "Genero",
                principalColumn: "Id_genero",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Filme_Diretor_DiretorId_diretor",
                table: "Filme");

            migrationBuilder.DropForeignKey(
                name: "FK_Filme_Genero_GeneroId_genero",
                table: "Filme");

            migrationBuilder.DropIndex(
                name: "IX_Filme_DiretorId_diretor",
                table: "Filme");

            migrationBuilder.DropIndex(
                name: "IX_Filme_GeneroId_genero",
                table: "Filme");

            migrationBuilder.DropColumn(
                name: "DiretorId_diretor",
                table: "Filme");

            migrationBuilder.DropColumn(
                name: "GeneroId_genero",
                table: "Filme");

            migrationBuilder.RenameColumn(
                name: "Id_diretor",
                table: "Filme",
                newName: "GeneroRefId");

            migrationBuilder.RenameColumn(
                name: "Id_Genero",
                table: "Filme",
                newName: "DiretorRefId");

            migrationBuilder.CreateIndex(
                name: "IX_Filme_DiretorRefId",
                table: "Filme",
                column: "DiretorRefId");

            migrationBuilder.CreateIndex(
                name: "IX_Filme_GeneroRefId",
                table: "Filme",
                column: "GeneroRefId");

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
    }
}
