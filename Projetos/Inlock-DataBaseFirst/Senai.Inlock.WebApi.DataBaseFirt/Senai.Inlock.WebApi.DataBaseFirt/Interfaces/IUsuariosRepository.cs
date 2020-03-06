using Senai.Inlock.WebApi.DataBaseFirt.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Inlock.WebApi.DataBaseFirt.Interfaces
{
    interface IUsuariosRepository
    {
        List<Usuarios> Listar();

        Usuarios BuscarId(int id);

        void Cadastrar(Usuarios user);

        void Atualizar(Usuarios user);

        void Deletar(int id);
    }
}
