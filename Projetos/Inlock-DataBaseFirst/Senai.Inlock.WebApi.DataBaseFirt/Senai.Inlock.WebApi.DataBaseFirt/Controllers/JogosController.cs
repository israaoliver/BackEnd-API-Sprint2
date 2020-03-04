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
    public class JogosController : ControllerBase
    {

        private IJogosRepository _jogosRepository;

        public JogosController()
        {
            _jogosRepository = new JogosRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_jogosRepository.Listar());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_jogosRepository.BuscarPorId(id));
        }

        [HttpPost]
        public IActionResult Post(Jogos jooj)
        {
            _jogosRepository.Cadastrar(jooj);
            return StatusCode(201);
        }

        [HttpDelete ("{id}")]
        public IActionResult Delete(int id)
        {
            _jogosRepository.Remover(id);
            return StatusCode(200);
        }
    }
}