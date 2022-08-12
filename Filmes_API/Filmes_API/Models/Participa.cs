namespace Filmes_API.Models
{
    public class Participa
    {
        public int Id { get; set; }

        public string titulo { get; set; } = string.Empty;
        public Filme Filme { get; set; }

        public string nome_elenco { get; set; } = string.Empty;
        public Elenco Elenco { get; set; }
    }
}
