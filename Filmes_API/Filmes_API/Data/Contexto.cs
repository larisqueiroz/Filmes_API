using Microsoft.EntityFrameworkCore;
using Filmes_API.Models;

using Microsoft.EntityFrameworkCore;
namespace Filmes_API.Data
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options) { }
        public DbSet<Filme> Filmes { get; set; }
        public DbSet<Diretor> Diretores { get; set; }
        public DbSet<Genero> Generos { get; set; }
    }
}
