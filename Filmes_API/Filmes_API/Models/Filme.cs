namespace Filmes_API.Models
{
    public class Filme
    {
        public int Id { get; set; }
        


        public string titulo { get; set; } = string.Empty;
        public int ano { get; set; }
        public int duracao { get; set; }
        public string sinopse { get; set; } = string.Empty;
        public float avaliacao_geral { get; set; }
        public string classif_indicativa { get; set; } = string.Empty;
        public string[] elenco { get; set; } = new string[3];

    }
}
