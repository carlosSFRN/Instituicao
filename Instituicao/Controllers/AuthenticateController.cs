using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Instituicao.Services;
using Instituicao.Models;
using Microsoft.AspNetCore.Authorization;
using Instituicao.Repositories.Interface;

namespace Instituicao.Controllers
{
    [Route("api/[controller]")]
    public class AuthenticateController : Controller
    {
        
        private readonly IAuthenticateRepository _context;
        public AuthenticateController(IAuthenticateRepository context)
        {
            _context = context;
        }
        
        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public ActionResult<dynamic> Authenticate([FromBody] Usuario usuario)
        {
            if (usuario.IdUsuario == 0)
            {
                return NotFound(new { message = "Usuário inválido" });
            }

            // Recupera o usuário
            var user = _context.Get(usuario.IdUsuario);

            // Verifica se o usuário existe
            if (user == null)
                return NotFound(new { message = "Usuário inválido" });

            // Gera o Token
            var token = TokenService.GenerateToken(user);

            // Retorna os dados
            return new
            {
                user = user,
                token = token
            };
        }

        [HttpGet]
        [Route("authenticated")]
        [Authorize]
        public string Authenticated() => String.Format("Autenticado - {0}", User.Identity.Name);
    }
}
