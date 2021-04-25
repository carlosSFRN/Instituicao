using Instituicao.Repositories.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Instituicao.Controllers
{
    [Route("api/{controller}")]
    public class AlunoNotaPorTurmaController : Controller
    {
        private readonly IAlunoNotaPorTurmaRepository _context;
        public AlunoNotaPorTurmaController(IAlunoNotaPorTurmaRepository context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Professor, Escola")]
        public IActionResult GetAlunoNotaPorTurmas(int Id)
        {
            var list = _context.GetAlunoNotaPorTurmas(Id);

            return Ok(list);
        }
    }
}
