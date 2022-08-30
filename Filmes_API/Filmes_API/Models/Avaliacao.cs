using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Filmes_API.Models
{
    public class Avaliacao
    {
        [Key]
        public int Id { get; set; }
        public float avaliacao { get; set; }

        [ForeignKey("Filme")]
        [Required]
        public int FilmeRefId { get; set; }

        [ForeignKey("Usuario")]
        public string UsuarioRefId { get; set; }
    }
}