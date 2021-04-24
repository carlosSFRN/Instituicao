using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Instituicao.Models
{
    public class Usuario
    {
        [Key]
        public int IdUsuario { get; set; }
        public string NomeUsuario { get; set; }
        public string Perfil { get; set; }
    }
}
