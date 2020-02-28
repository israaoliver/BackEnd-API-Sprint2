using Senai.Peoples.WebApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Interfaces
{
    interface IUsuariosRepository
    {

        List<UsuariosDomain> Listar();

        void Cadastrar(UsuariosDomain user); 

        UsuariosDomain BuscarPorId(int id);

        void Atualizar(UsuariosDomain user);

        void Deletar(int id);


    }
}
