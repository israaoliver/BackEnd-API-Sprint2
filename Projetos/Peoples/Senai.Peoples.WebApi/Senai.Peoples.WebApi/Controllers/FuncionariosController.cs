using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        [HttpGet]
        public IEnumerable<FuncionariosDomain> Listar()
        {
            return _funcionarioRepository.Listar();
        }

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

        [HttpGet ("BuscarNome")]
        public IEnumerable<FuncionariosDomain> BuscarNome(FuncionariosDomain f)
        {
            return _funcionarioRepository.BuscarNome(f);


        }

        [HttpGet ("NomesCompletos")]
        public IEnumerable<NomeDomain> NomesCompletos()
        {


            return _funcionarioRepository.NomeCompleto();

        }

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