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
        public int Id { get; set; }
        public int Nome { get; set; }
        public int Perfil { get; set; }
    }
}
