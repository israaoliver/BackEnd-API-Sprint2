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

        [HttpPost]
        public IActionResult Cadastrar(FuncionariosDomain funcionario)
        {
            if (funcionario.Nome == "")
            {
                return BadRequest("Nome Funcionario Vazio");
            }else if (funcionario.Sobrenome == "")
            {
                return BadRequest("Sobrenome Funcionario Vazio");
            }


            _funcionarioRepository.Cadastrar(funcionario);

            return StatusCode(201);


        }
    }
}