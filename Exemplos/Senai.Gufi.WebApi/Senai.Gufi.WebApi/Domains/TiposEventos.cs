using System;
using System.Collections.Generic;

namespace Senai.Gufi.WebApi.Domains
{
    public partial class TiposEventos
    {
        public TiposEventos()
        {
            Eventos = new HashSet<Eventos>();
        }

        public int IdTipoEvento { get; set; }
        public string TituloTipoEvento { get; set; }

        public ICollection<Eventos> Eventos { get; set; }
    }
}
