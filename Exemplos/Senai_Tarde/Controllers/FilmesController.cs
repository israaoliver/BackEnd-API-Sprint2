using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    public class FilmesController : ControllerBase
    {
        private IFilmesRepository _filmesRepository {get; set;}

        public FilmesController()
        {
            _filmesRepository = new FilmesRepository();
        }

        [HttpGet]
        public IEnumerable<FilmeDomain> Get()
        {
           return _filmesRepository.Listar();

        }

        [HttpGet ("Buscar")]
        public IActionResult Get(FilmeDomain tituloBusca)
        {
            List<FilmeDomain> filmeAchado = new List<FilmeDomain>();

            filmeAchado = _filmesRepository.BuscarPorTitulo(tituloBusca);
            if (filmeAchado.Count == 0)
            {
                return NotFound("Nenhum titulo encontrado");
            }
            return Ok(filmeAchado);
        }

        [HttpGet ("{id}")]
        public IActionResult BuscaId(int id)
        {
            FilmeDomain filmePegado = _filmesRepository.BuscarId(id);

            if(filmePegado != null)
            {
                return Ok(filmePegado);
            }

            return NotFound("Nenhum gênero encontrado");
        }

        [HttpPost]
        public IActionResult Criar(FilmeDomain novoFilme)
        {
            _filmesRepository.Cadastrar(novoFilme);

            return StatusCode(201);
        }

        [HttpPut ("{id}")]
        public IActionResult Atualizar(int id, FilmeDomain atulizaFilme)
        {

            if(_filmesRepository.BuscarId(id) == null)
            {
                return NotFound("Não Acho");
            }

            _filmesRepository.AtualizarFilme(id, atulizaFilme);
            return Ok("Tudo certo");
        }


        [HttpDelete ("{id}")]
        public IActionResult Delete(int id)
        {
            _filmesRepository.DeletarFilme(id);

            return StatusCode(204);
        }


    }
}
