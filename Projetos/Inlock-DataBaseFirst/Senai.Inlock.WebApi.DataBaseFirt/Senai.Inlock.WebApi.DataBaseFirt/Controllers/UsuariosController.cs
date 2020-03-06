using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Inlock.WebApi.DataBaseFirt.Domains;
using Senai.Inlock.WebApi.DataBaseFirt.Interfaces;
using Senai.Inlock.WebApi.DataBaseFirt.Repositories;

namespace Senai.Inlock.WebApi.DataBaseFirt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private IUsuariosRepository _usuariosRepository { get; set; }

        public UsuariosController()
        {
            _usuariosRepository = new UsuariosRepository();
        }


        [HttpGet]
        public IActionResult Listar()
        {
            var users = _usuariosRepository.Listar();

            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult BuscarId(int id)
        {
            var tipo = _usuariosRepository.BuscarId(id);

            if (tipo != null)
            {
                return Ok(tipo);
            }

            return NotFound("Nenhum Usuario com esse id!");
        }

        [HttpPost]
        public IActionResult Cadastrar(Usuarios user)
        {
            _usuariosRepository.Cadastrar(user);

            return StatusCode(201);
        }

        [HttpPut]
        public IActionResult Atualizar(Usuarios user)
        {
            _usuariosRepository.Atualizar(user);

            return StatusCode(202);
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            _usuariosRepository.Deletar(id);

            return StatusCode(202);
        }
    }
}