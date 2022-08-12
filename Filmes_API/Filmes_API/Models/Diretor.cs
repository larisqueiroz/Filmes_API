namespace Filmes_API.Models
{
    public class Diretor
    {
        public int Id_diretor { get; set; }
        public string nome_diretor { get; set; } = string.Empty;

        public List<Filme> Filmes { get; set; }

        public Diretor(string nome_campo)
        {
            nome_diretor = nome_campo;

        }

        public Diretor(int id_campo, string nome_campo)
        {
            Id_diretor = id_campo;
            nome_diretor = nome_campo;
        }
    }
}
