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
using System.Security.Claims;
using Filmes_API.Auth;
using Microsoft.AspNetCore.Identity;

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

        private void atualiza_nota_media(int id) // iterar em notas, se id == id_filme
        {

            float soma_notas = _contexto.Avaliacoes.Where(x => x.FilmeRefId == id).Sum(i => i.avaliacao);
            int total_usuarios = _contexto.Avaliacoes.Where(x => x.FilmeRefId == id).Count();
            //int total_usuarios = _contexto.Users.Count();

            float media_final = soma_notas / total_usuarios;

            var valor_atualizado = _contexto.Filmes.Find(id);
            valor_atualizado.nota = media_final;
            _contexto.Entry(valor_atualizado).State = EntityState.Modified;
            _contexto.SaveChanges();
        }

        /// <summary>
        /// Lista todos os filmes.
        /// </summary>
        /// <returns>Retorna os filmes cadastrados</returns>
        /// <response code="200">Lista de filmes cadastrados</response>
        [HttpGet]
        public async Task<ActionResult<List<Filme>>> Get()
        {
            var filmes = _contexto.Filmes.Include(x => x.Diretor).Include(x => x.Genero);
            return Ok(filmes.ToList());
        }

        /// <summary>
        /// Cadastra um novo filme.
        /// </summary>
        /// <returns>Retorna todos os filmes e o novo cadastrado.</returns>
        [HttpPost]
        public async Task<ActionResult<List<Filme>>> AddFilme(Filme filme)
        {
            _contexto.Filmes.Add(filme);
            await _contexto.SaveChangesAsync();
            var filmes = _contexto.Filmes.Include(x => x.Diretor).Include(x => x.Genero);
            return Ok(filmes.ToList());
        }

        /// <summary>
        /// Pesquisa um filme pelo título ou parte dele.
        /// </summary>
        /// <returns>Retorna o filme pesquisado.</returns>
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

        /// <summary>
        /// Edita um filme pelo id.
        /// </summary>
        /// <returns>Retorna todos os filmes e o editado.</returns>
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

        /// <summary>
        /// Faz a avaliação de um filme.
        /// </summary>
        [HttpPost("{id}/avaliacao")]
        public async Task<ActionResult> avaliacao(int id, [FromBody]Avaliacao avaliacao)
        {
            string id_usuario_logado = User.Identity.Name;

            if (_contexto.Avaliacoes.Any(x => x.UsuarioRefId == id_usuario_logado && x.FilmeRefId == id) == true)
            {
                return BadRequest("Usuário já votou nesse filme.");
            }

            avaliacao.UsuarioRefId = id_usuario_logado;

            _contexto.Avaliacoes.Add(avaliacao);
            await _contexto.SaveChangesAsync();

            atualiza_nota_media(id);

            return Ok(await _contexto.Avaliacoes.Where(x => x.UsuarioRefId == id_usuario_logado && x.FilmeRefId == id).ToListAsync());
        }

        /// <summary>
        /// Faz a leitura das avaliações do usuário online.
        /// </summary>
        [HttpGet("avaliacoes")]
        public async Task<ActionResult<List<Avaliacao>>> GetAvaliacoes()
        {
            var id_usuario_logado = User.Identity.Name;
            var notas = await _contexto.Avaliacoes.Where(x => x.UsuarioRefId == id_usuario_logado).ToListAsync();
            return Ok(notas);
        }
        
    }

}
