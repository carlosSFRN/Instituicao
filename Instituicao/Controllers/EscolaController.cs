using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Instituicao.Models;
using Instituicao.Repositories.Interface;

namespace Instituicao.Controllers
{
    [Route("api/{controller}")]
    public class EscolaController : Controller
    {
        private readonly IEscolaRepository _context;
        public EscolaController(IEscolaRepository context)
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
        public IActionResult EditarUsuario([FromRoute] int id, [FromBody] Escola escola)
        {
            _context.Edit(escola);

            return Ok();
        }


        [HttpPost]
        [Authorize(Roles = "Escola")]
        public IActionResult AdicionaUsuario([FromBody] Escola escola)
        {
            _context.Add(escola);

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
