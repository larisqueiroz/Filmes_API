
namespace Filmes_API.Models
{
    public class Usuario
    {
        public int Id_usuario { get; set; }

        public string usuario { get; set; } = string.Empty;
        public string senha { get; set; } = string.Empty;

        public List<Avaliacao> Avaliacoes { get; set; }

        public Usuario (string usuario_campo, string senha_campo)
        {
            usuario = usuario_campo;
            senha = senha_campo;
        }

        public Usuario(int id_campo, string usuario_campo, string senha_campo)
        {
            Id_usuario = id_campo;
            usuario = usuario_campo;
            senha = senha_campo;
        }

    }
}
