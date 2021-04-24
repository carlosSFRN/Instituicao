using Instituicao.Models;
using Instituicao.Repositories.Interface;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Instituicao.Data;

namespace Instituicao.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly string conexao = DbContext.GetConnection();

        public IEnumerable<Usuario> GetAll() 
        {
            List<Usuario> listaUsuario = new List<Usuario>();

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
                    Usuario usuario = new Usuario
                    {
                        IdUsuario = Convert.ToInt32(rdr["IdUsuario"]),
                        NomeUsuario = rdr["NomeUsuario"].ToString(),
                        Perfil = rdr["Perfil"].ToString()
                    };

                    listaUsuario.Add(usuario);
                }
                con.Close();
            }
            return listaUsuario;

        }
        public void Add(Usuario usuario)
        {
            using (SqlConnection con = new SqlConnection(conexao))
            {
                SqlCommand cmd = new SqlCommand("stp_Usuario_Ins", con)
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 60
                };

                cmd.Parameters.AddWithValue("@NomeUsuario", usuario.NomeUsuario);
                cmd.Parameters.AddWithValue("@Perfil", usuario.Perfil);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public void Edit(Usuario usuario)
        {
            using (SqlConnection con = new SqlConnection(conexao))
            {
                SqlCommand cmd = new SqlCommand("stp_Usuario_Upd", con)
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 60
                };

                cmd.Parameters.AddWithValue("@IdUsuario", usuario.IdUsuario);
                cmd.Parameters.AddWithValue("@NomeUsuario", usuario.NomeUsuario);
                cmd.Parameters.AddWithValue("@Perfil", usuario.Perfil);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

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
        public void Delete(int? id)
        {
            using (SqlConnection con = new SqlConnection(conexao))
            {
                SqlCommand cmd = new SqlCommand("stp_Usuario_Del", con)
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 60
                };

                cmd.Parameters.AddWithValue("@IdUsuario", id);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
