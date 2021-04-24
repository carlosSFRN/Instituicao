using Instituicao.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Instituicao.Repositories.Interface
{
    public interface ITurmaRepository
    {
        IEnumerable<Turma> GetAll();
        Turma GetPorId(int? id);
        void Add(Turma turma);
        void Edit(Turma turma);
        void Delete(int? id);
    }
}
