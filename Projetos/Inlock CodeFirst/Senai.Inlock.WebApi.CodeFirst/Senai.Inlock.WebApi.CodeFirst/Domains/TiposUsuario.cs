using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Inlock.WebApi.CodeFirst.Domains
{
    [Table("TiposUsuario")]
    public class TiposUsuario
    {
        // Define que sera uma chave primaria
        [Key]
        // Define o auto-incrementa
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdTipoUsuario { get; set; }
        
        [Column(TypeName ="VARCHAR (255)")]
        [Required(ErrorMessage ="O titulo do tipo de usuario é obrigatorio")]
        public string Titulo { get; set; }

    }
}
