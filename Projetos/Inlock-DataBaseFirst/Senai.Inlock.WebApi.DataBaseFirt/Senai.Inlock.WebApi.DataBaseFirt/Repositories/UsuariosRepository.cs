using Senai.Inlock.WebApi.DataBaseFirt.Domains;
using Senai.Inlock.WebApi.DataBaseFirt.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Inlock.WebApi.DataBaseFirt.Repositories
{
    public class UsuariosRepository : IUsuariosRepository
    {

        InlockContextr ctx = new InlockContextr();

        public void Atualizar(Usuarios user)
        {
            ctx.Usuarios.Update(user);
            ctx.SaveChanges();
        }

        public Usuarios BuscarId(int id)
        {
            return ctx.Usuarios.FirstOrDefault(user => user.IdUsuario == id);
        }

        public void Cadastrar(Usuarios user)
        {
            ctx.Usuarios.Add(user);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.Usuarios.Remove(BuscarId(id));
            ctx.SaveChanges();
        }

        public List<Usuarios> Listar()
        {
            return ctx.Usuarios.ToList();
        }
    }
}
