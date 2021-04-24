using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Instituicao.Models;

namespace Instituicao.Repositories.Interface
{
    public interface IUsuarioRepository
    {
        IEnumerable<Usuario> GetAll();
        void Add(Usuario usuario);
        void Edit(Usuario usuario);
        Usuario Get(int? id);
        void Delete(int? id);
    }
}
