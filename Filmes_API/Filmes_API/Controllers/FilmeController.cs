using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Filmes_API.Models;
using Filmes_API.Data;
using Microsoft.EntityFrameworkCore;
using System.Web;
using System;
using System.Text;

namespace Filmes_API.Controllers
{
    [Route("api/filmes")]
    [ApiController]
    public class FilmeController : ControllerBase
    {
        /*public List<Filme> filmes = new List<Filme>
        {
        new Filme
            {
                Id_filme = 1,
                nota = 9.5f,
                titulo = "Brilho Eterno de Uma Mente Sem Lembranças",
                ano = 2004,
                duracao = 108,
                sinopse = "Quando sua relaçao se volta complicada, um casal tenta um procedimento " +
                "médico para que suas memorias sejam apagadas.",
                classif_indicativa = "14",
            },

            new Filme
            {
                Id_filme = 2,
                nota = 9.5f,
                titulo = "Waking Life",
                ano = 2001,
                duracao = 99,
                sinopse = "Um homem constrói um sonho ao encontrar várias pessoas e discutir os significados " +
                "e propósitos do universo.",
                classif_indicativa = "Livre",
            },
        };*/
        private readonly Contexto _contexto;

        public FilmeController(Contexto contexto)
        {
            _contexto = contexto;
        }

        [HttpGet]
        public async Task<ActionResult<List<Filme>>> Get()
        {
            var filmes = _contexto.Filmes.Include(x => x.Diretor).Include(x => x.Genero);
            return Ok(filmes.ToList());
        }

        [HttpPost]
        public async Task<ActionResult<List<Filme>>> AddFilme(Filme filme)
        {
            _contexto.Filmes.Add(filme);
            await _contexto.SaveChangesAsync();
            var filmes = _contexto.Filmes.Include(x => x.Diretor).Include(x => x.Genero);
            return Ok(filmes.ToList());
        }

        [HttpGet("pesquisa")]
        public async Task<ActionResult<List<Filme>>> PesquisaFilme(string titulo_filme)
        {
            IQueryable<Filme> query = _contexto.Filmes.Include(x => x.Diretor).Include(x => x.Genero);

            byte[] bytes = Encoding.Default.GetBytes(titulo_filme);
            string titulo_utf8 = Encoding.UTF8.GetString(bytes);

            if (!string.IsNullOrEmpty(titulo_filme))
            {
                query = query.Where(x => x.titulo.ToLower().Contains(titulo_utf8.ToLower()));
                
            }

            return Ok(await query.ToListAsync());
        }
    }

}
