using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Instituicao.Data
{
    public class DbContext
    {
        private static string conexao;
        public static string GetConnection() 
        {
            return conexao = @"Server=DESKTOP-29H7J25\SQLEXPRESS;Database=InstituicaoDB;Trusted_Connection=True;";
        }
    }
}
