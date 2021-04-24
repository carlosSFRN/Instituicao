using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Instituicao.Services;
using Instituicao.Models;
using Microsoft.AspNetCore.Authorization;
using Instituicao.Data;
using Microsoft.EntityFrameworkCore;


namespace Instituicao.Controllers
{
    [Route("api/[controller]")]
    public class HomeController : Controller
    {
        
        private readonly DataContext _context;
        public HomeController(DataContext context)
        {
            _context = context;
        }
        

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public ActionResult<dynamic> Authenticate([FromBody] Usuario usuario)
        {
            // Recupera o usuário
            var user = Get(usuario.Id);

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

        public Usuario Get(int? id) 
        {
            Usuario usuario =  _context.Usuario.Find(id);

            return usuario;
        }

        [HttpGet]
        [Route("authenticated")]
        [Authorize]
        public string Authenticated() => String.Format("Autenticado - {0}", User.Identity.Name);
    }
}
