using Senai.Gufi.WebApi.Domains;
using Senai.Gufi.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Gufi.WebApi.Repositories
{
    public class TipoEventoRepository : ITipoEventoRepository
    {
        GufiContextr ctx = new GufiContextr();

        public void Atualizar(int id, TiposEventos novoTipoEvento)
        {
            var tipoEventoBuscado = ctx.TiposEventos.Find(id);

            tipoEventoBuscado.TituloTipoEvento = novoTipoEvento.TituloTipoEvento;

            ctx.SaveChanges();

        }

        public TiposEventos BuscarId(int id)
        {
            return ctx.TiposEventos.FirstOrDefault(e => e.IdTipoEvento == id);
        }

        public void Cadastrar(TiposEventos novoTipoEvento)
        {
            ctx.TiposEventos.Add(novoTipoEvento);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.TiposEventos.Remove(ctx.TiposEventos.Find(id));
            ctx.SaveChanges();
        }

        public List<TiposEventos> Listar()
        {
           return ctx.TiposEventos.ToList();
        }
    }
}
