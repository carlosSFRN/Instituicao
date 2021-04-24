using Instituicao.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Instituicao.Repositories.Interface
{
    public interface IAlunoRepository
    {
        IEnumerable<Aluno> GetAll();
        Aluno GetPorId(int? id);
        void Add(Aluno aluno);
        void Edit(Aluno aluno);
        void Delete(int? id);
    }
}
