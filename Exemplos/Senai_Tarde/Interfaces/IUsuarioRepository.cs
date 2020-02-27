using Senai_Tarde.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_Tarde.Interfaces
{
    interface IUsuarioRepository
    {
        UsuarioDomain BuscarPorEmailSenha(string email,string senha);
    }
}
