namespace Filmes_API.Models
{
    public class Filme
    {
        public int Id_filme { get; set; }
        public float nota { get; set; }
        public string titulo { get; set; } = string.Empty;
        public int ano { get; set; }
        public int duracao { get; set; }
        public string sinopse { get; set; } = string.Empty;
        public string classif_indicativa { get; set; } = string.Empty;

        public string nome_diretor { get; set; } = string.Empty;
        public Diretor Diretor { get; set; }
        public string genero { get; set; } = string.Empty;
        public Genero Genero { get; set; }

        public List<Participa> Participa { get; set; }
        public List<Avaliacao> Avaliacoes { get; set; }


        public Filme(float nota_campo, string titulo_campo, int ano_campo, int duracao_campo, 
            string sinopse_campo, string classif_ind_campo)
        {
            nota = nota_campo;
            titulo = titulo_campo;
            ano = ano_campo;
            duracao = duracao_campo;
            sinopse = sinopse_campo;
            classif_indicativa = classif_ind_campo;
        }

        public Filme(int id_campo, float nota_campo, string titulo_campo, int ano_campo, int duracao_campo,
            string sinopse_campo, string classif_ind_campo)
        {
            Id_filme = id_campo;
            nota = nota_campo;
            titulo = titulo_campo;
            ano = ano_campo;
            duracao = duracao_campo;
            sinopse = sinopse_campo;
            classif_indicativa = classif_ind_campo;
        }

    }
}
