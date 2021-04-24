using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Instituicao.Models
{
    public class Turma
    {
        public int IdTurma { get; set; }
        public string NomeTurma { get; set; }
        public int EscolaId { get; set; }
    }
}
