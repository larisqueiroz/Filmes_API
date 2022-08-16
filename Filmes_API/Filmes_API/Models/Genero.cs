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

        /*public Genero(string genero_campo)
        {
            genero = genero_campo;
        }

        public Genero(int id_campo, string genero_campo)
        {
            Id_genero = id_campo;
            genero = genero_campo;
        }*/
    }
}
