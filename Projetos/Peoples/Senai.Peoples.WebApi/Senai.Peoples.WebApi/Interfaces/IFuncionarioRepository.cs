using Senai.Peoples.WebApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Interfaces
{
    interface IFuncionarioRepository
    {
        List<FuncionariosDomain> Listar();

        FuncionariosDomain BuscarId();

        void Cadastrar(FuncionariosDomain funcionario);

        void Deletar(int id);

        FuncionariosDomain Atulizar(int id, FuncionariosDomain funcionario);
        
    }


}
