using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Peoples.WebApi.Domain;
using Senai.Peoples.WebApi.Interfaces;
using Senai.Peoples.WebApi.Repositories;

namespace Senai.Peoples.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class TiposUsuariosController : ControllerBase
    {
        private ITiposUsuariosRepository _tiposUsuariosRepository  { get; set; }

        public TiposUsuariosController()
        {
            _tiposUsuariosRepository = new TiposUsuariosRepository();
        }

        [Authorize(Roles = "1")]
        [HttpGet]
        public IEnumerable<TiposUsuariosDomain> Listar()
        {
            return _tiposUsuariosRepository.Listar();
        }

        [Authorize(Roles = "1")]
        [HttpGet ("{id}")]
        public IActionResult BuscarId(int id)
        {
            var t = _tiposUsuariosRepository.BuscarPorId(id);

            if (t == null)
            {
                return NotFound("Funcionario Inexistente");
            }

            return Ok(t);
        }

        [Authorize(Roles = "1")]
        [HttpPut]
        public IActionResult Atualizar(TiposUsuariosDomain tipo)
        {
            var t_Existente = _tiposUsuariosRepository.BuscarPorId(tipo.IdTipoUsuario);

            if (t_Existente == null)
            {
                return NotFound("Funcionario Inexistente");
            }

            _tiposUsuariosRepository.Atualizar(tipo);
            return StatusCode(301);

        }

        [Authorize(Roles = "1")]
        [HttpDelete ("{id}")]
        public IActionResult Delete(int id)
        {
            var t_Existente = _tiposUsuariosRepository.BuscarPorId(id);

            if (t_Existente == null)
            {
                return NotFound("Funcionario Inexistente");
            }

            _tiposUsuariosRepository.Deletar(id);
            return StatusCode(200);
        }

    }
}