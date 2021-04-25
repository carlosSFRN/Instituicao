using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Instituicao.Models
{
    public class AlunoNotaPorTurma
    {
        public int IdTurma { get; set; }
        public string NomeTurma { get; set; }
        public string NomeAluno { get; set; }
        public decimal NotaAluno { get; set; }
    }
}
