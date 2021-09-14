using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using senai.inlock.webApi_.Domains;
using senai.inlock.webApi_.Interfaces;
using senai.inlock.webApi_.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace senai.inlock.webApi_.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private IUsuarioRepository _UsuarioRepository { get; set; }

        public UsuariosController()
        {
            _UsuarioRepository = new UsuarioRepository();
        }

        [HttpPost]
        public IActionResult Login(UsuarioDomain Login)
        {
            UsuarioDomain UsuarioBuscado = _UsuarioRepository.Login(Login.Email, Login.Senha);

            if (UsuarioBuscado == null)
                return NotFound("Email ou senha invalidos");

            //return Ok(UsuarioBuscado);

            var MinhasClaims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, UsuarioBuscado.Email),
                new Claim(JwtRegisteredClaimNames.Jti, UsuarioBuscado.IdUsuario.ToString()),
                new Claim(ClaimTypes.Role, UsuarioBuscado.IdTipoUsuario.ToString())
            };

            var Key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("alkhjgbaauehrfajbsdgaew"));

            var Creds = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256);

            var MeuToken = new JwtSecurityToken(
                    issuer: "Inlko.WebApi",
                    audience: "Inlko.WebApi",
                    claims: MinhasClaims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: Creds
                );

            return Ok(new
            {
                Token = new JwtSecurityTokenHandler().WriteToken(MeuToken)
            });
        }
    }
}
