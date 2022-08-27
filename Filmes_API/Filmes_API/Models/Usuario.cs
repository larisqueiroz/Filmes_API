using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Filmes_API.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [ForeignKey("Login")]
        [Required]
        public int LoginRefId { get; set; }

        public static List<Avaliacao> Avaliacoes { get; set; } = new List<Avaliacao>();
    }
}