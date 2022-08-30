using Filmes_API.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;

namespace Filmes_API.Controllers
{
    [Route("api/usuario")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _usuario;
        private readonly RoleManager<IdentityRole> _permissoes;
        private readonly IConfiguration _configuracao;

        public LoginController(
            UserManager<IdentityUser> usuario,
            RoleManager<IdentityRole> permissoes,
            IConfiguration configuracao)
        {
            _usuario = usuario;
            _permissoes = permissoes;
            _configuracao = configuracao;
        }

        private JwtSecurityToken getToken(List<Claim> claims)
        {
            var chave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuracao["JWT:Key"]));

            var jwt = new JwtSecurityToken(
                issuer: _configuracao["JWT:ValidIssuer"],
                audience: _configuracao["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(3),
                claims: claims,
                signingCredentials: new SigningCredentials(chave, SecurityAlgorithms.HmacSha256));

                return jwt;
        }

        /// <summary>
        /// Cadastra um novo usuário.
        /// </summary>
        [HttpPost]
        [Route("novousuario")]
        public async Task<IActionResult> Cadastro([FromBody] Cadastro cadastro)
        {
            var usuario_existente = await _usuario.FindByNameAsync(cadastro.username);
            if (usuario_existente != null)
                return BadRequest("Username já existe.");

            IdentityUser user = new()
            {
                Email = cadastro.email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = cadastro.username
            };
            var resultado = await _usuario.CreateAsync(user, cadastro.senha);
            if (!resultado.Succeeded)
                return BadRequest("Erro. A senha deve ter pelo menos uma letra maiúscula, um número e um símbolo.");

            return Ok("Usuário criado com sucesso.");
        }

        /// <summary>
        /// Cadastra um novo usuário admin.
        /// </summary>
        [HttpPost]
        [Route("novoadmin")]
        public async Task<IActionResult> CadastroAdmin([FromBody] Cadastro cadastro)
        {
            var usuario_existente = await _usuario.FindByNameAsync(cadastro.username);
            if (usuario_existente != null)
                return BadRequest("Username já existe.");

            IdentityUser user = new()
            {
                Email = cadastro.email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = cadastro.username
            };
            var resultado = await _usuario.CreateAsync(user, cadastro.senha);
            if (!resultado.Succeeded)
                return BadRequest("Erro. A senha deve ter pelo menos uma letra maiúscula, um número e um símbolo.");

            if (!await _permissoes.RoleExistsAsync(UsuarioTipo.admin))
                await _permissoes.CreateAsync(new IdentityRole(UsuarioTipo.admin));
            if (!await _permissoes.RoleExistsAsync(UsuarioTipo.usuario))
                await _permissoes.CreateAsync(new IdentityRole(UsuarioTipo.usuario));

            if (await _permissoes.RoleExistsAsync(UsuarioTipo.admin))
            {
                await _usuario.AddToRoleAsync(user, UsuarioTipo.admin);
            }
            if (await _permissoes.RoleExistsAsync(UsuarioTipo.admin))
            {
                await _usuario.AddToRoleAsync(user, UsuarioTipo.usuario);
            }

            return Ok("Usuário administrador criado com sucesso.");
        }

        /// <summary>
        /// Faz o login no sistema.
        /// </summary>
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] Login login)
        {
            var usuario = await _usuario.FindByNameAsync(login.username);
            if (usuario != null && await _usuario.CheckPasswordAsync(usuario, login.senha)){
                var permissoes = await _usuario.GetRolesAsync(usuario);

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, login.username),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                foreach (var permissao in permissoes)
                {
                    claims.Add(new Claim(ClaimTypes.Role, permissao));
                }

                var token = getToken(claims);

                return Ok("Bearer " + new JwtSecurityTokenHandler().WriteToken(token));
            }
            return Unauthorized("Usuário ou senha inválido. Tente novamente");
            
        }

    }
}
