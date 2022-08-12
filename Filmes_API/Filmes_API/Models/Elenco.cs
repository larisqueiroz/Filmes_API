namespace Filmes_API.Models
{
    public class Elenco
    {
        public int Id_elenco { get; set; }
        public string nome_elenco { get; set; } = string.Empty;

        public List<Participa> Participa { get; set; }

        public Elenco(string nome_campo)
        {
            nome_elenco = nome_campo;
        }

        public Elenco(int id_campo, string nome_campo)
        {
            Id_elenco = id_campo;
            nome_elenco = nome_campo;
        }
    }
}
