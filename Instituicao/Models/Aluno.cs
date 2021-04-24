using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Instituicao.Models
{
    public class Aluno
    {
        public int IdAluno { get; set; }
        public string NomeAluno { get; set; }
        public decimal Nota { get; set; }
        public int TurmaId { get; set; }
    }
}
