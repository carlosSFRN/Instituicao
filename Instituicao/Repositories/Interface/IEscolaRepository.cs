using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Instituicao.Models;

namespace Instituicao.Repositories.Interface
{
    public interface IEscolaRepository
    {
        IEnumerable<Escola> GetAll();
        Escola GetPorId(int? id);
        void Add(Escola escola);
        void Edit(Escola escola);
        void Delete(int? id);
    }
}
