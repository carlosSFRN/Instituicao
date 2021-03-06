using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Instituicao.Models;
using Instituicao.Repositories.Interface;

namespace Instituicao.Controllers
{
    [Route("api/{controller}")]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepository _context;
        public UsuarioController(IUsuarioRepository context)
        {
            _context = context;
        }

        [HttpGet]
        [Authorize(Roles = "Professor, Escola")]
        public IActionResult GetList()
        {
            var list =  _context.GetAll();

            return Ok(list);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Escola")]
        public IActionResult EditarUsuario([FromRoute] int id, [FromBody] Usuario usuario)
        {
            _context.Edit(usuario);

            return Ok();
        }


        [HttpPost]
        [Authorize(Roles = "Escola")]
        public IActionResult AdicionaUsuario([FromBody] Usuario usuario)
        {
            _context.Add(usuario);
            
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
