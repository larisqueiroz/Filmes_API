using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Filmes_API.Models;
using Filmes_API.Data;
using Microsoft.EntityFrameworkCore;
using System.Web;
using System;
using System.Text;

namespace Filmes_API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/filmes")]
    public class FilmeController : ControllerBase
    {
        public readonly Contexto _contexto;

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

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Filme>>> EditaFilme(int id, Filme filme)
        {
            IQueryable<Filme> query;

            if (id != filme.Id)
            {
                return BadRequest();
            }

            _contexto.Entry(filme).State = EntityState.Modified;

            await _contexto.SaveChangesAsync();

            return Ok(await _contexto.Filmes.Include(x => x.Diretor).Include(x => x.Genero).ToListAsync());
        }
    }

}
