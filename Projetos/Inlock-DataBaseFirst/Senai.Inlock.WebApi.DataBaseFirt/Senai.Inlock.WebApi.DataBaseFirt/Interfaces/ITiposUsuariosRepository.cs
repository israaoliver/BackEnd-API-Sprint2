using Senai.Inlock.WebApi.DataBaseFirt.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Inlock.WebApi.DataBaseFirt.Interfaces
{
    interface ITiposUsuariosRepository
    {

        List<TiposUsuarios> Listar();

        TiposUsuarios BuscarId(int id);

        void Cadastrar(TiposUsuarios tipo);

        void Atualizar(TiposUsuarios tipo);

        void Deletar(int id);
    }
}
