using Microsoft.AspNetCore.Mvc;
using Filmes_API.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Filmes_API.Data;
using Microsoft.AspNetCore.Authorization;

namespace Filmes_API.Controllers
{
    [Route("api/diretores")]
    [ApiController]
    public class DiretorController : ControllerBase
    {
        private readonly Contexto _contexto;

        public DiretorController(Contexto contexto)
        {
            _contexto = contexto;
        }

        /*[HttpGet]
        public async Task<ActionResult<List<Diretor>>> Get()
        {
            return Ok(await _contexto.Diretores.ToListAsync());
        }*/
    }
}
