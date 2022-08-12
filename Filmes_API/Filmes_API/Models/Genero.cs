namespace Filmes_API.Models
{
    public class Genero
    {
        public int Id_genero { get; set; }
        public string genero { get; set; } = string.Empty;

        public List<Filme> Filmes { get; set; }

        public Genero(string genero_campo)
        {
            genero = genero_campo;
        }

        public Genero(int id_campo, string genero_campo)
        {
            Id_genero = id_campo;
            genero = genero_campo;
        }
    }
}
