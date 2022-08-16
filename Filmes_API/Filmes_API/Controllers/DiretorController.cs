using Microsoft.AspNetCore.Mvc;
using Filmes_API.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Filmes_API.Data;

namespace Filmes_API.Controllers
{
    [Route("api/diretores")]
    [ApiController]
    public class DiretorController : ControllerBase
    {
        /*private static List<Diretor> diretores = new List<Diretor>
        {

        new Diretor
            {
                Id_diretor = 1,
                nome_diretor = "Michel Gondry",
        },

        new Diretor
            {
                Id_diretor = 2,
                nome_diretor = "Richard Linklater",
            },
        };*/


        private readonly Contexto _contexto;

        public DiretorController(Contexto contexto)
        {
            _contexto = contexto;
        }

        [HttpGet]
        public async Task<ActionResult<List<Diretor>>> Get()
        {
            return Ok(await _contexto.Diretores.ToListAsync());
        }
    }
}
