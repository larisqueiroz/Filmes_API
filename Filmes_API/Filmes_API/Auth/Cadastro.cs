using System.ComponentModel.DataAnnotations;
namespace Filmes_API.Auth
{
    public class Cadastro
    {
        [Required]
        public string username { get; set; }

        [EmailAddress]
        public string email { get; set; }

        [Required]
        public string senha { get; set; }
    }
}
