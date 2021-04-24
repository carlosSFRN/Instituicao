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
    public class TurmaController : Controller
    {
        private readonly ITurmaRepository _context;
        public TurmaController(ITurmaRepository context)
        {
            _context = context;
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
        public IActionResult EditarUsuario([FromRoute] int id, [FromBody] Turma turma)
        {
            _context.Edit(turma);

            return Ok();
        }


        [HttpPost]
        [Authorize(Roles = "Escola")]
        public IActionResult AdicionaUsuario([FromBody] Turma turma)
        {
            _context.Add(turma);

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
