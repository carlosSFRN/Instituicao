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
    public class MediaTurmaController : Controller
    {

        private readonly IMediaTurmaRepository _context;
        public MediaTurmaController(IMediaTurmaRepository context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Professor, Escola")]
        public IActionResult GetTurmaMediaPorId(int Id)
        {
            var list = _context.GetTurmaMediaPorId(Id);

            return Ok(list);
        }
    }
}
