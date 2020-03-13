using Senai.Gufi.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Gufi.WebApi.Interfaces
{
    interface ITipoUsuarioRepository
    {

        List<TiposUsuarios> Listar();

        TiposUsuarios BuscarId(int id);

        void Cadastrar(TiposUsuarios novoTpu);

        void Atualizar(int id, TiposUsuarios atualizaTpu);

        void Deletar(int id);
    }
}
