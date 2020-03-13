using Senai.Gufi.WebApi.Domains;
using Senai.Gufi.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Gufi.WebApi.Interfaces
{
    interface IUsuarioRepository
    {

        List<Usuarios> Listar();

        Usuarios BuscarId(int id);

        void Cadastrar(Usuarios novoUser);

        void Atualizar(int id, Usuarios atualizaUser);

        void Deletar(int id);

        Usuarios Login(LoginViewModel user);    
    }
}
