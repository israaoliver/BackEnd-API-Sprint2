using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Gufi.WebApi.Domains;
using Senai.Gufi.WebApi.Interfaces;
using Senai.Gufi.WebApi.Repositories;

namespace Senai.Gufi.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class TipoEventoController : ControllerBase
    {
        private ITipoEventoRepository _tipoEventoRepository;

        // cto mais dois tab cria o construtor 
        public TipoEventoController()
        {
             _tipoEventoRepository = new TipoEventoRepository();
        }
       

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_tipoEventoRepository.Listar());
        }

        [HttpGet("{id}")]
        public IActionResult BuscarId(int id)
        {
            var buscado = _tipoEventoRepository.BuscarId(id);

            if(buscado != null)
            {
                return StatusCode(200, buscado);
            }

            return NotFound("Tipo não encontrado");
        }

        [HttpPost]
        public IActionResult Cadastrar(TiposEventos tpe)
        {
            _tipoEventoRepository.Cadastrar(tpe);
            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, TiposEventos tpeAtualizado)
        {
            var tpeExistente = _tipoEventoRepository.BuscarId(id);

            if (tpeExistente != null)
            {
                try
                {
                    _tipoEventoRepository.Atualizar(id, tpeAtualizado);
                }
                catch (Exception error)
                {

                    return BadRequest(error);
                }

            }

            return NotFound("Tipo Evento não encontrado");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var tpeExistente = _tipoEventoRepository.BuscarId(id);

            if (tpeExistente != null)
            {
                _tipoEventoRepository.Deletar(id);
                return Ok();
            }

            return NotFound("Tipo Evento não encontrado");
        }
    }
}