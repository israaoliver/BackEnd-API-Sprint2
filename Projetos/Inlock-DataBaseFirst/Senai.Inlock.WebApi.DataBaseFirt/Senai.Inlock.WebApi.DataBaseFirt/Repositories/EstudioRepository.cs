using Senai.Inlock.WebApi.DataBaseFirt.Domains;
using Senai.Inlock.WebApi.DataBaseFirt.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Inlock.WebApi.DataBaseFirt.Repositories
{
    public class EstudioRepository : IEstudioRepository
    {

        InlockContextr ctx = new InlockContextr();

        public Estudios BuscarId(int id)
        {
            return ctx.Estudios.FirstOrDefault(e => e.IdEstudio == id);
        }

        public void Cadastrar(Estudios estudio)
        {
            ctx.Estudios.Add(estudio);
            ctx.SaveChanges();
        }

        public List<Estudios> Listar()
        {
            return ctx.Estudios.ToList();
        }
    }
}
