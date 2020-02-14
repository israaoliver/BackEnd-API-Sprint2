using Senai_Tarde.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_Tarde.Interfaces
{
    interface IGeneroRepository
    {
        /// <summary>
        /// Lista todos os generos
        /// </summary>
        /// <returns>Retorna uma lista de generos</returns>
        List<GeneroDomain> Listar();
    }
}
