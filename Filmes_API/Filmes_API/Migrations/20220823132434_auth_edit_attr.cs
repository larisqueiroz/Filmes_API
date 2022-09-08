using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Filmes_API.Migrations
{
    public partial class auth_edit_attr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "password",
                table: "Login",
                newName: "senha");

            migrationBuilder.RenameColumn(
                name: "password",
                table: "Cadastro",
                newName: "senha");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "senha",
                table: "Login",
                newName: "password");

            migrationBuilder.RenameColumn(
                name: "senha",
                table: "Cadastro",
                newName: "password");
        }
    }
}
