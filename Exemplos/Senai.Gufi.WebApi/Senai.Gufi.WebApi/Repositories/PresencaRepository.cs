using Senai.Gufi.WebApi.Domains;
using Senai.Gufi.WebApi.Interfaces;
using Senai.Gufi.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Gufi.WebApi.Repositories
{
    public class PresencaRepository : IPresencaRepository
    {
        private GufiContextr ctx = new GufiContextr();

        public void AlterarSituacao(int idPrensenca, string tipoAlteracao)
        {
            throw new NotImplementedException();
        }

        public void Atualizar(int id, Presencas atualizaPresenca)
        {
            atualizaPresenca.IdPrecenca = id;

            ctx.Presencas.Update(atualizaPresenca);
            ctx.SaveChanges();
        }

        public Presencas BuscarId(int id)
        {
            return ctx.Presencas.Find(id);
        }

        public void Convidar(ConviteViewModel convite)
        {
            Presencas presenca = new Presencas
            {
                IdEvento = convite.IdEvento,
                IdUsuario = convite.IdUsuarioConvidado ,
                Situacao = convite.Situacao
            };

            ctx.Presencas.Add(presenca);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.Presencas.Remove(ctx.Presencas.Find(id));
            ctx.SaveChanges();
        }

        public void Inscricao(Presencas novaPresenca)
        {
            ctx.Presencas.Add(novaPresenca);
            ctx.SaveChanges();
        }

        public List<Presencas> Listar()
        {
            return ctx.Presencas.ToList();
        }

        public List<Presencas> ListarMinhasPresencas(int idUser)
        {
            return ctx.Presencas.Where(e => e.IdUsuario == idUser).ToList();
        }
    }
}
