using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Filmes_API.Models;
using Filmes_API.Data;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Filmes_API.Controllers
{
    [Route("api/genero")]
    [ApiController]
    public class GeneroController : ControllerBase
    {

        /*private static List<Genero> generos = new List<Genero>
        {
        new Genero
            {
                Id_genero = 1,
                genero = "Drama",
        },

        new Genero
            {
                Id_genero = 2,
                genero = "Animação",
            },
        };*/

        private readonly Contexto _contexto;

        public GeneroController(Contexto contexto)
        {
            _contexto = contexto;
        }

        [HttpGet]
        public async Task<ActionResult<List<Genero>>> Get()
        {
            return Ok(await _contexto.Generos.ToListAsync());
        }
    }
}
