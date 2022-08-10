using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Filmes_API.Models;

namespace Filmes_API.Controllers
{
    [Route("api/filmes")]
    [ApiController]
    public class FilmeController : ControllerBase
    {
        private static List<Filme> filmes = new List<Filme>
        {
            new Filme
            {
                Id = 1,
                titulo = "Brilho Eterno de Uma Mente Sem Lembranças",
                ano = 2004,
                duracao = 108,
                sinopse = "Quando sua relaçao se volta complicada, um casal tenta um procedimento " +
                "médico para que suas memorias sejam apagadas.",
                avaliacao_geral = 0,
                classif_indicativa = "14",
                elenco = new string[] { "Jim Carrey", "Kate Winslet", "Tom Wilkinson"}
            },

            new Filme
            {
                Id = 2,
                titulo = "Waking Life",
                ano = 2001,
                duracao = 99,
                sinopse = "Um homem constrói um sonho ao encontrar várias pessoas e discutir os significados " +
                "e propósitos do universo.",
                avaliacao_geral = 0,
                classif_indicativa = "Livre",
                elenco = new string[] { "Ethan Hawke", "Trevor Jake Brooks", "Lorelei Linklater"}
            },
        };

        [HttpGet]
        public async Task<ActionResult<List<Filme>>> Get()
        {
            return Ok(filmes);
        }
    }
}
