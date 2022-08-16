using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Filmes_API.Models
{
    [Table("Filme")]
    public class Filme
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Genero")]
        [Required]
        public int GeneroRefId { get; set; }
        public Genero Genero { get; set; } = new Genero();

        [ForeignKey("Diretor")]
        [Required]
        public int DiretorRefId { get; set; }
        public Diretor Diretor { get; set; } = new Diretor();

        public float nota { get; set; }
        public string titulo { get; set; } = string.Empty;
        public int ano { get; set; }
        public int duracao { get; set; }
        public string sinopse { get; set; } = string.Empty;
        public string classif_indicativa { get; set; } = string.Empty;


        /*public Filme(int diretorId, int generoId, float nota_campo, string titulo_campo, int ano_campo, int duracao_campo, 
            string sinopse_campo, string classif_ind_campo)
        {
            nota = nota_campo;
            titulo = titulo_campo;
            ano = ano_campo;
            duracao = duracao_campo;
            sinopse = sinopse_campo;
            classif_indicativa = classif_ind_campo;
        }

        public Filme(int id_campo, int diretorId, int generoId, float nota_campo, string titulo_campo, int ano_campo, int duracao_campo,
            string sinopse_campo, string classif_ind_campo)
        {
            Id_filme = id_campo;
            nota = nota_campo;
            titulo = titulo_campo;
            ano = ano_campo;
            duracao = duracao_campo;
            sinopse = sinopse_campo;
            classif_indicativa = classif_ind_campo;
        }*/

    }

  
}
