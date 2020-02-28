using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai_Tarde.Domains;
using Senai_Tarde.Interfaces;
using Senai_Tarde.Repositories;

namespace Senai_Tarde.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class GenerosController : ControllerBase
    {
        private IGeneroRepository _generoRepository {get; set;}

        public GenerosController()
        {
            _generoRepository = new GeneroRepository();
        }

        [HttpGet]
        public IEnumerable<GeneroDomain> Get()
        {
            return _generoRepository.Listar();
        }

        [HttpGet("{id}")]
        public IActionResult  Get(int id)
        {
            return StatusCode (200,_generoRepository.Buscar(id));
        }


        [Authorize]
        [HttpPost]
        public IActionResult Post(GeneroDomain genero)
        {
            _generoRepository.Cadastrar(genero);

            return StatusCode(201);
        }

        
        [HttpDelete("{id}")]
        public IActionResult Delete (int id)
        {
               _generoRepository.Deletar(id);

                return StatusCode(202);

        }

        [HttpPut]
        public GeneroDomain Put(GeneroDomain genero)
        {
            

            return _generoRepository.Atualizar(genero);
        }
    }
}
