﻿using System;
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
    public class UsuariosController : ControllerBase
    {
        private IUsuariosRepository _usuariosRepository { get; set; }

        public UsuariosController()
        {
            _usuariosRepository = new UsuariosRepository();
        }

        [HttpGet]
        public IEnumerable<UsuariosDomain> Listar()
        {
            return _usuariosRepository.Listar();
        }

        [HttpGet ("{id}")]
        public IActionResult BuscarId(int id)
        {
            var user = _usuariosRepository.BuscarPorId(id);

            if (user == null)
            {
                return NotFound("Usuario Inexistente");
            }

            return Ok(user);
        }

        [HttpPost]
        public IActionResult Cadastrar(UsuariosDomain user)
        {
            _usuariosRepository.Cadastrar(user);

            return StatusCode(201);
        }

        [HttpPut]
        public IActionResult Atualizar(UsuariosDomain user)
        {
            var existe = _usuariosRepository.BuscarPorId(user.IdUsuarios);

            if(existe == null)
            {
                return NotFound("Usuario Inexistente");
            }

            _usuariosRepository.Atualizar(user);
            return StatusCode(201);
        }

        [HttpDelete ("{id}")]
        public IActionResult Deletar(int id)
        {
            var existe = _usuariosRepository.BuscarPorId(id);

            if (existe == null)
            {
                return NotFound("Funcionario Inexistente");
            }

            _usuariosRepository.Deletar(id);
            return StatusCode(200);
        }
    }
}