using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Gufi.WebApi.Domains;
using Senai.Gufi.WebApi.Interfaces;
using Senai.Gufi.WebApi.Repositories;
using Senai.Gufi.WebApi.ViewModels;

namespace Senai.Gufi.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class PresencasController : ControllerBase
    {
        private IPresencaRepository _presencaRepository;

        public PresencasController()
        {
            _presencaRepository = new PresencaRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_presencaRepository.Listar());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var pres = _presencaRepository.BuscarId(id);
            
           
            if (pres != null)
            {
                return Ok(pres);
            }

            return NotFound("Presença não encontrada");
        }

        [HttpPost]
        public IActionResult Inscricao(Presencas presenca)
        {
            try
            {
                _presencaRepository.Inscricao(presenca);

                return StatusCode(201);
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        [HttpPost("Convidar")]
        public IActionResult Convidar(ConviteViewModel convite)
        {
            _presencaRepository.Convidar(convite);

            return StatusCode(201);
        }

    }
}