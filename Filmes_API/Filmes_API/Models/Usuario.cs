using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Filmes_API.Models
{
    public class Usuario: IdentityUser
    {

        public static List<Avaliacao> Avaliacoes { get; set; } = new List<Avaliacao>();
    }
}