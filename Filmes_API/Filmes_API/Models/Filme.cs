using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
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

        public static List<Avaliacao> Avaliacoes { get; set; } = new List<Avaliacao>();

    }

  
}
