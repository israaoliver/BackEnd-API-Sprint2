using Senai.Inlock.WebApi.DataBaseFirt.Domains;
using Senai.Inlock.WebApi.DataBaseFirt.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Inlock.WebApi.DataBaseFirt.Repositories
{
    public class JogosRepository : IJogosRepository
    {

        InlockContextr ctx = new InlockContextr();

        public void Atualizar(Jogos jooj)
        {
            ctx.Jogos.Update(jooj);
            ctx.SaveChanges();
        }


        public Jogos BuscarPorId(int id)
        {
            return ctx.Jogos.FirstOrDefault(j => j.IdJogos == id);
        }

        public void Cadastrar(Jogos joojs)
        {
            ctx.Jogos.Add(joojs);
            ctx.SaveChanges();
        }

        public List<Jogos> Listar()
        {
           return ctx.Jogos.ToList();
  
        }

        public void Remover(int id)
        {
            var joojs = ctx.Jogos.FirstOrDefault(j => j.IdJogos == id);
            ctx.Jogos.Remove(joojs);
            ctx.SaveChanges();
        }
    }
}
