using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Filmes_API.Models;
using Filmes_API.Data;
using Microsoft.EntityFrameworkCore;

namespace Filmes_API.Controllers
{
    [Route("api/usuarios")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly Contexto _contexto;

        public UsuarioController(Contexto contexto)
        {
            _contexto = contexto;
        }

        /*[HttpGet]
        public async Task<ActionResult<Usuario>> Get(Login login)
        {
            _contexto.Usuarios.FirstOrDefault(x => x.username.Equals
            (login.username, StringComparison.OrdinalIgnoreCase) && x.senha.Equals(login.senha));

            return Ok(await _contexto.Usuarios.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<List<Usuario>>> AddUsuario(Usuario usuario)
        {
            _contexto.Usuarios.Add(usuario);
            await _contexto.SaveChangesAsync();
            return Ok(await _contexto.Usuarios.ToListAsync());
        }*/

        
    }
}
