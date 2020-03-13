using Senai.Gufi.WebApi.Domains;
using Senai.Gufi.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Gufi.WebApi.Interfaces
{
    interface IPresencaRepository
    {

        List<Presencas> Listar();

        Presencas BuscarId(int id);

        void Atualizar(int id, Presencas atualizaPresenca);

        void Deletar(int id);

        void Inscricao(Presencas novaPrecenca);

        void Convidar(ConviteViewModel convite);

        void AlterarSituacao(int idPrensenca, string tipoAlteracao);

        List<Presencas> ListarMinhasPresencas(int idUser);




    }
}
