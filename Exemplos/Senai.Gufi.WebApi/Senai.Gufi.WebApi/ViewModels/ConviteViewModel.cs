using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Gufi.WebApi.ViewModels
{
    public class ConviteViewModel
    {
        public int IdUsuarioConvidado { get; set; }

        public int IdEvento { get; set; }

        public string Situacao { get; set; }
    }
}
