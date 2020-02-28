using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Domain
{
    public class UsuariosDomain
    {
        public int IdUsuarios { get; set;}

        public int IdTipoUsuario { get; set; }

        public string Email { get; set; }

        public string Senha { get; set; }

        public TiposUsuariosDomain TipoUsuario { get; set; }

        public UsuariosDomain ()
        {
            this.TipoUsuario = new TiposUsuariosDomain();
        }


    }
}
