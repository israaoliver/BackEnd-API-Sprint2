using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Senai.Peoples.WebApi.Domain;
using Senai.Peoples.WebApi.Interfaces;
using Senai.Peoples.WebApi.Repositories;

namespace Senai.Peoples.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IUsuariosRepository _usuariosRepository { get; set; }
        
        public LoginController()
        {
            _usuariosRepository = new UsuariosRepository();
        }

        [HttpPost]
        public IActionResult Login(UsuariosDomain user)
        {
            var user_exist = _usuariosRepository.Autenticando(user.Email, user.Senha);

            if(user_exist == null)
            {
                return NotFound("E-mail ou senha inválidos");
            }

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, user_exist.Email),
                new Claim(JwtRegisteredClaimNames.Jti, user_exist.IdUsuarios.ToString()),
                new Claim(ClaimTypes.Role, user_exist.IdTipoUsuario.ToString()),
                new Claim("So pra ver", "Tama ae né")
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("peoples-usuarios-autenticacao-key"));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "Peoples.WebApi",
                audience: "Peoples.WebApi",
                claims: claims,
                expires: DateTime.Now.AddMinutes(10),
                signingCredentials: creds
            );

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token)
            });
        }
    }
}