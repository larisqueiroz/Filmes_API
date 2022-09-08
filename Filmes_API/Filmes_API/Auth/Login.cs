using System.ComponentModel.DataAnnotations;
namespace Filmes_API.Auth
{
    public class Login
    {
        public int Id { get; set; }

        [Required]
        public string username { get; set; }

        [Required]
        public string senha { get; set; }

    }
}
