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

        FuncionariosDomain BuscarId(int id);

        void Cadastrar(FuncionariosDomain funcionario);

        void Deletar(int id);

        void Atulizar(int id, FuncionariosDomain f);

        List<FuncionariosDomain> BuscarNome(FuncionariosDomain f);

        List<NomeDomain> NomeCompleto();
        
    }


}
