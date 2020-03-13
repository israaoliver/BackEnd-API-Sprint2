using Senai.Gufi.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Gufi.WebApi.Interfaces
{
    interface IInstituicaoRepository
    {

        List<Instituicoes> Listar();

        Instituicoes BuscarId(int id);

        void Cadastrar(Instituicoes novaInstituicao);

        void Atualizar(int id, Instituicoes atualizaInstituicao);

        void Deletar(int id);
    }
}
