using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        [HttpGet]
        public IEnumerable<TiposUsuariosDomain> Listar()
        {
            return _tiposUsuariosRepository.Listar();
        }

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