using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
namespace Filmes_API.Models
{
    [Table("Genero")]
    public class Genero
    {
        [Key]
        public int Id { get; set; }
        public string genero { get; set; } = string.Empty;

        public static List<Filme> Filmes { get; set; } =  new List<Filme>();

    }
}
