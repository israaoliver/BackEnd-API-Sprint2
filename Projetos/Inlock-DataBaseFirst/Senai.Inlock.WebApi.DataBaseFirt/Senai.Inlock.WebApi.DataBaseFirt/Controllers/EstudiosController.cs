using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Inlock.WebApi.DataBaseFirt.Interfaces;
using Senai.Inlock.WebApi.DataBaseFirt.Repositories;
using Senai.Inlock.WebApi.DataBaseFirt.Domains;

namespace Senai.Inlock.WebApi.DataBaseFirt.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class EstudiosController : ControllerBase
    {

        private IEstudioRepository _estudioRepository;

        public EstudiosController()
        {
            _estudioRepository = new EstudioRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_estudioRepository.Listar());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_estudioRepository.BuscarId(id));
        }

        [HttpPost]
        public IActionResult Post(Estudios estudio)
        {
            _estudioRepository.Cadastrar(estudio);

            return StatusCode(201);
        }

    }
}