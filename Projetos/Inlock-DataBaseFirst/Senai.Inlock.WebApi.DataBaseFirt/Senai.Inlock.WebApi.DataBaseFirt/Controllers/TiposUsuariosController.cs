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
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class TiposUsuariosController : ControllerBase
    {
        private ITiposUsuariosRepository _tipoUsuariosRepository;

        public TiposUsuariosController()
        {
            _tipoUsuariosRepository = new TiposUsuariosRepository();
        }

        [HttpGet]
        public IActionResult Listar()
        {
            var tipos = _tipoUsuariosRepository.Listar();

            return Ok(tipos);
        }

        [HttpGet ("{id}")]
        public IActionResult BuscarId(int id)
        {
            var tipo = _tipoUsuariosRepository.BuscarId(id);

            if(tipo != null)
            {
                return Ok(tipo);
            }

            return NotFound("Nenhum Tipo com esse nome!");
        }

        [HttpPost]
        public IActionResult Cadastrar(TiposUsuarios tipo)
        {
            _tipoUsuariosRepository.Cadastrar(tipo);

            return StatusCode(201);
        }

        [HttpPut]
        public IActionResult Atualizar(TiposUsuarios tipo)
        {
            _tipoUsuariosRepository.Atualizar(tipo);

            return StatusCode(202);
        }

        [HttpDelete ("{id}")]
        public IActionResult Deletar(int id)
        {
            _tipoUsuariosRepository.Deletar(id);

            return StatusCode(202);
        }
    }
}