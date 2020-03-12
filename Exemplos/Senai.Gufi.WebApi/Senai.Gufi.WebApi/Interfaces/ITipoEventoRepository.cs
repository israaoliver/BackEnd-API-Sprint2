using Senai.Gufi.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Gufi.WebApi.Interfaces
{
    interface ITipoEventoRepository
    {
        List<TiposEventos> Listar();

        void Cadastrar(TiposEventos novoTipoEvento);

        void Atualizar(int id, TiposEventos novoTipoEvento);

        void Deletar(int id);

        TiposEventos BuscarId(int id);
    }
}
