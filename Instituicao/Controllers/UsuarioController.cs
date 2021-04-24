using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Instituicao.Models;
using Instituicao.Data;
using Microsoft.EntityFrameworkCore;

namespace Instituicao.Controllers
{
    [Route("api/{controller}")]
    public class UsuarioController : Controller
    {
        private readonly DataContext _context;
        public UsuarioController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Authorize(Roles = "Professor, Escola")]
        public async Task<IActionResult> GetList()
        {
            var list = await _context.Usuario.ToListAsync();

            return Ok(list);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Escola")]
        public async Task<IActionResult> EditarUsuario([FromRoute] int id, [FromBody] Usuario usuario)
        {
            if (id != usuario.Id)
            {
                return BadRequest();
            }

            _context.Entry(usuario).State = EntityState.Modified;
            var list = await _context.SaveChangesAsync();

            return Ok(list);
        }


        [HttpPost]
        [Authorize(Roles = "Escola")]
        public async Task<IActionResult> AdicionaUsuario([FromBody] Usuario usuario)
        {
            _context.Usuario.Add(usuario);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Escola")]
        public async Task<IActionResult> Delete([FromRoute] int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuario.FindAsync(id);

            if (usuario == null)
            {
                return NotFound();
            }

            _context.Usuario.Remove(usuario);

            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
