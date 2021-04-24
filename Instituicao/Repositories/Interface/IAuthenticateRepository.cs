using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Instituicao.Models;

namespace Instituicao.Repositories.Interface
{
    public interface IAuthenticateRepository
    {
        Usuario Get(int? id);
    }
}
