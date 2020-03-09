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

        private IJogosRepository _jogosRepository { get; set; }

        public EstudioRepository()
        {
            _jogosRepository = new JogosRepository();
        }

        InlockContextr ctx = new InlockContextr();

        public void Atualizar(Estudios estudios)
        {
            ctx.Estudios.Update(estudios);
            ctx.SaveChanges();

        }

        public Estudios BuscarId(int id)
        {
            var estudio = ctx.Estudios.FirstOrDefault(e => e.IdEstudio == id);


            return estudio;
        }

        public void Cadastrar(Estudios estudio)
        {
            ctx.Estudios.Add(estudio);
            ctx.SaveChanges();
        }

        public List<Estudios> Listar()
        {
            var estudios = ctx.Estudios.ToList();
            
             estudios.ForEach(e => e.Jogos = _jogosRepository.Listar().Where(j => j.IdEstudio == e.IdEstudio).ToList());

            
            return estudios;
        }
    }
}
