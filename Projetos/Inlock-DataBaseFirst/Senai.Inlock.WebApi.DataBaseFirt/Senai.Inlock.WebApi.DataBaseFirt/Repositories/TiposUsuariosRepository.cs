using Senai.Inlock.WebApi.DataBaseFirt.Domains;
using Senai.Inlock.WebApi.DataBaseFirt.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Inlock.WebApi.DataBaseFirt.Repositories
{
    public class TiposUsuariosRepository : ITiposUsuariosRepository
    {

        InlockContextr ctx = new InlockContextr();

        public void Atualizar(TiposUsuarios tipo)
        {
            ctx.TiposUsuarios.Update(tipo);
            ctx.SaveChanges();
        }

        public TiposUsuarios BuscarId(int id)
        {
            return ctx.TiposUsuarios.FirstOrDefault(t => t.IdTipoUsuario == id);
        }

        public void Cadastrar(TiposUsuarios tipo)
        {
            ctx.TiposUsuarios.Add(tipo);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.TiposUsuarios.Remove(BuscarId(id));
            ctx.SaveChanges();
        }

        public List<TiposUsuarios> Listar()
        {
            return ctx.TiposUsuarios.ToList();
        }
    }
}
