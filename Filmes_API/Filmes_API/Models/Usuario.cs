using Microsoft.EntityFrameworkCore;

namespace Filmes_API.Models
{
    public class Usuario
    {
        public string username { get; set; }
        public string email { get; set; }
        public string senha { get; set; }
        public string nome { get; set; }
        public string sobrenome { get; set; }

        public string permissoes { get; set; }
    }
}
