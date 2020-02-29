using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Senai.Peoples.WebApi.Domain;
using Senai.Peoples.WebApi.Interfaces;
using Senai.Peoples.WebApi.Repositories;

namespace Senai.Peoples.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionariosController : Controller
    {
        private IFuncionarioRepository _funcionarioRepository { get; set; }

        public FuncionariosController()
        {
            _funcionarioRepository = new FuncionarioRepository();
        }

        [Authorize(Roles = "2")]
        [HttpGet]
        public IEnumerable<FuncionariosDomain> Listar()
        {
            return _funcionarioRepository.Listar();
        }

        [Authorize(Roles = "2")]
        [HttpGet ("{id}")]
        public IActionResult BuscarId(int id)
        {
            var f =_funcionarioRepository.BuscarId(id);

            if(f == null)
            {
                return NotFound("Funcionario Inexistente");
            }
            return Ok(f);
        }

        [Authorize(Roles = "2")]
        [HttpGet ("BuscarNome")]
        public IEnumerable<FuncionariosDomain> BuscarNome(FuncionariosDomain f)
        {
            return _funcionarioRepository.BuscarNome(f);


        }

        [Authorize(Roles = "2")]
        [HttpGet ("NomesCompletos")]
        public IEnumerable<NomeDomain> NomesCompletos()
        {


            return _funcionarioRepository.NomeCompleto();

        }

        [Authorize(Roles = "1")]
        [HttpPut ("{id}")]
        public IActionResult Atualizar(int id, FuncionariosDomain f)
        {
            var f_Existente = _funcionarioRepository.BuscarId(id);

            if (f_Existente == null)
            {
                return NotFound("Funcionario Inexistente");
            }
            _funcionarioRepository.Atulizar(id, f);
            return StatusCode(301);


        }

        [Authorize(Roles = "2")]
        [HttpPost]
        public IActionResult Cadastrar(FuncionariosDomain funcionario)
        {
            if ((funcionario.Nome == "") || (funcionario.Sobrenome == ""))
            {
                return BadRequest("Campo em  Funcionario Vazio");
            }



            _funcionarioRepository.Cadastrar(funcionario);

            return StatusCode(201);
        }

        [Authorize(Roles = "1")]
        [HttpDelete ("{id}")]
        public IActionResult Deletar(int id)
        {
            var f_Existente = _funcionarioRepository.BuscarId(id);

            if (f_Existente == null)
            {
                return NotFound("Funcionario Inexistente");
            }

            _funcionarioRepository.Deletar(id);

            return StatusCode(200);

        }
    }
}