using Senai.Peoples.WebApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Interfaces
{
    interface ITiposUsuariosRepository
    {
        List<TiposUsuariosDomain> Listar();

        TiposUsuariosDomain BuscarPorId(int id);

        void Atualizar(TiposUsuariosDomain tipo);

        void Deletar(int id);
    }
}
