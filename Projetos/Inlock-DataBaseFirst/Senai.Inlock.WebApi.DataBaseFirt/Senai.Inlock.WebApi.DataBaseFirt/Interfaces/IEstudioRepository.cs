using Senai.Inlock.WebApi.DataBaseFirt.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Inlock.WebApi.DataBaseFirt.Interfaces
{
    interface IEstudioRepository
    {

        List<Estudios> Listar();

        Estudios BuscarId(int id);

        void Cadastrar(Estudios estudio);
    }
}
