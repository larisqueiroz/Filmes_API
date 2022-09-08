using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Filmes_API.Models;
using Filmes_API.Auth;

namespace Filmes_API.Data
{
    public class Contexto : IdentityDbContext<IdentityUser>//DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options) { }
        public DbSet<Filme> Filmes { get; set; }
        public DbSet<Diretor> Diretores { get; set; }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<Avaliacao> Avaliacoes { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Cadastro>().HasNoKey();
            //builder.Entity<Login>().HasNoKey();
            base.OnModelCreating(builder);
        }

    }

}
