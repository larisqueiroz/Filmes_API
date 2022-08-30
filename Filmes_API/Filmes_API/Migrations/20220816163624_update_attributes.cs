using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Filmes_API.Migrations
{
    public partial class update_attributes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Filme_Diretor_DiretorId_diretor",
                table: "Filme");

            migrationBuilder.DropForeignKey(
                name: "FK_Filme_Genero_GeneroId_genero",
                table: "Filme");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Filme",
                table: "Filme");

            migrationBuilder.DropIndex(
                name: "IX_Filme_DiretorId_diretor",
                table: "Filme");

            migrationBuilder.DropIndex(
                name: "IX_Filme_GeneroId_genero",
                table: "Filme");

            migrationBuilder.DropColumn(
                name: "Id_filme",
                table: "Filme");

            migrationBuilder.DropColumn(
                name: "DiretorId_diretor",
                table: "Filme");

            migrationBuilder.RenameColumn(
                name: "Id_genero",
                table: "Genero",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "Id_diretor",
                table: "Filme",
                newName: "GeneroRefId");

            migrationBuilder.RenameColumn(
                name: "Id_Genero",
                table: "Filme",
                newName: "DiretorRefId");

            migrationBuilder.RenameColumn(
                name: "GeneroId_genero",
                table: "Filme",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "Id_diretor",
                table: "Diretor",
                newName: "Id");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Filme",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Filme",
                table: "Filme",
                column: "Id");

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
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Filme_Genero_GeneroRefId",
                table: "Filme",
                column: "GeneroRefId",
                principalTable: "Genero",
                principalColumn: "Id",
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

            migrationBuilder.DropPrimaryKey(
                name: "PK_Filme",
                table: "Filme");

            migrationBuilder.DropIndex(
                name: "IX_Filme_DiretorRefId",
                table: "Filme");

            migrationBuilder.DropIndex(
                name: "IX_Filme_GeneroRefId",
                table: "Filme");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Genero",
                newName: "Id_genero");

            migrationBuilder.RenameColumn(
                name: "GeneroRefId",
                table: "Filme",
                newName: "Id_diretor");

            migrationBuilder.RenameColumn(
                name: "DiretorRefId",
                table: "Filme",
                newName: "Id_Genero");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Filme",
                newName: "GeneroId_genero");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Diretor",
                newName: "Id_diretor");

            migrationBuilder.AlterColumn<int>(
                name: "GeneroId_genero",
                table: "Filme",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "Id_filme",
                table: "Filme",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "DiretorId_diretor",
                table: "Filme",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Filme",
                table: "Filme",
                column: "Id_filme");

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
    }
}
