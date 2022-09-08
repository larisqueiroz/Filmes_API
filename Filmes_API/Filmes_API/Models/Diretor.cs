using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Filmes_API.Models
{
    [Table("Diretor")]
    public class Diretor
    {
        [Key]
        public int Id { get; set; }

        public string nome_diretor { get; set; } = string.Empty;

        public static List<Filme> Filmes { get; set; } = new List<Filme>();

    }
}
