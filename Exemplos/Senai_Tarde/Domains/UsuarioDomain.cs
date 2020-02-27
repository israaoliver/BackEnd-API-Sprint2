using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_Tarde.Domains
{
    public class UsuarioDomain
    {
        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "Informe o e-mail")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage ="Informe a Senha")]
        [StringLength(20,MinimumLength = 3, ErrorMessage ="A senha tem que ter entre 3 a 20")]
        public string Senha { get; set; }

        public string Permissao { get; set; }
    }
}
