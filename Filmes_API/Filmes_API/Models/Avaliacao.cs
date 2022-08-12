namespace Filmes_API.Models
{
    public class Avaliacao
    {
        public int Id_avaliacao { get; set; }
        public float nota { get; set; }

        public string titulo { get; set; } = string.Empty;
        public Filme Filme { get; set; }

        public string usuario { get; set; } =  string.Empty;
        public Usuario Usuario { get; set; }

        public Avaliacao(float nota_campo)
        {
            nota = nota_campo;
        }

        public Avaliacao(int id_campo, float nota_campo)
        {
            Id_avaliacao = id_campo;
            nota = nota_campo;
        }

    }
}
