using Instituicao.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Instituicao.Repositories.Interface
{
    public interface IMediaTurmaRepository
    {
        IEnumerable<MediaTurma> GetTurmaMediaPorId(int? id);
    }
}
