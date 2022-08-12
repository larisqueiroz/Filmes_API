using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Filmes_API.Models;

namespace Filmes_API.Controllers
{
    [Route("api/filmes")]
    [ApiController]
    public class FilmeController : ControllerBase
    {
        Filme filme = new Filme(1,
                9.5f,
                "Brilho Eterno de Uma Mente Sem Lembranças",
                2004,
                108,
                "Quando sua relaçao se volta complicada, um casal tenta um procedimento " +
                "médico para que suas memorias sejam apagadas.",
                "14");



    [HttpGet]
        public async Task<ActionResult<List<Filme>>> Get()
        {
            return Ok(filme);
        }
    }
}
