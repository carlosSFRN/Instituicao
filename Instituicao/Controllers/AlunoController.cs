using Instituicao.Models;
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
    public class AlunoController : Controller
    {
        private readonly IAlunoRepository _context;
        private readonly ITurmaRepository _contextTurma;
        public AlunoController(IAlunoRepository context, ITurmaRepository contextTurma)
        {
            _context = context;
            _contextTurma = contextTurma;
        }

        [HttpGet]
        [Authorize(Roles = "Professor, Escola")]
        public IActionResult GetList()
        {
            var list = _context.GetAll();

            return Ok(list);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Professor, Escola")]
        public IActionResult GetPorId(int Id)
        {
            var list = _context.GetPorId(Id);

            return Ok(list);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Escola")]
        public IActionResult EditarUsuario([FromRoute] int id, [FromBody] Aluno aluno)
        {
            var list = _contextTurma.GetPorId(aluno.TurmaId);

            if (list.IdTurma == null)
            {
                return BadRequest("Essa turma não existe");
            }

            _context.Edit(aluno);

            return Ok();
        }


        [HttpPost]
        [Authorize(Roles = "Escola")]
        public IActionResult AdicionaUsuario([FromBody] Aluno aluno)
        {
            var list = _contextTurma.GetPorId(aluno.TurmaId);

            if (list.IdTurma == null)
            {
                return BadRequest("Essa turma não existe");
            }

            _context.Add(aluno);

            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Escola")]
        public IActionResult Delete([FromRoute] int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            _context.Delete(id);

            return Ok();
        }
    }
}
