using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Instituicao.Services;
using Instituicao.Models;
using Microsoft.AspNetCore.Authorization;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using Instituicao.Repositories.Interface;
using Instituicao.Data;

namespace Instituicao.Repositories
{
    public class AuthenticateRepository : IAuthenticateRepository
    {
        private readonly string conexao = DbContext.GetConnection();

        public Usuario Get(int? id)
        {
            Usuario usuario = new Usuario();

            using (SqlConnection con = new SqlConnection(conexao))
            {
                SqlCommand cmd = new SqlCommand("stp_Usuario_Sel", con)
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 60
                };

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    if (id == Convert.ToInt32(rdr["IdUsuario"]))
                    {
                        usuario.IdUsuario = Convert.ToInt32(rdr["IdUsuario"]);
                        usuario.NomeUsuario = rdr["NomeUsuario"].ToString();
                        usuario.Perfil = rdr["Perfil"].ToString();
                        break;
                    }
                }
            }
            return usuario;
        }
    }
}
