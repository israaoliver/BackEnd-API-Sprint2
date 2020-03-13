using Senai.Gufi.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Gufi.WebApi.Interfaces
{
    interface IEventoRepository
    {
        List<Eventos> Listar();

        Eventos Buscarid(int id);

        void Cadastrar(Eventos novoEvento);

        void Atualizar(int id, Eventos atualizaEvento);

        void Deletar(int id);
    }
}
