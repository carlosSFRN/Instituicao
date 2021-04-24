using Instituicao.Data;
using Instituicao.Models;
using Instituicao.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Instituicao.Repositories
{
    public class EscolaRepository : IEscolaRepository
    {
        private readonly string conexao = DbContext.GetConnection();

        public IEnumerable<Escola> GetAll()
        {
            List<Escola> listaEscola = new List<Escola>();

            using (SqlConnection con = new SqlConnection(conexao))
            {
                SqlCommand cmd = new SqlCommand("stp_Escola_Sel", con)
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 60
                };

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Escola escola = new Escola
                    {
                        IdEscola = Convert.ToInt32(rdr["IdEscola"]),
                        NomeEscola = rdr["NomeEscola"].ToString()
                    };

                    listaEscola.Add(escola);
                }
                con.Close();
            }
            return listaEscola;

        }
        public Escola GetPorId(int? id)
        {
            Escola escola = new Escola();

            using (SqlConnection con = new SqlConnection(conexao))
            {
                SqlCommand cmd = new SqlCommand("stp_Escola_Sel", con)
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 60
                };

                cmd.Parameters.AddWithValue("@IdEscola", id);
                cmd.Parameters.AddWithValue("@TipoConsulta", "PorId");

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    escola.IdEscola = Convert.ToInt32(rdr["IdEscola"]);
                    escola.NomeEscola = rdr["NomeEscola"].ToString();
                }
            }
            return escola;
        }
        public void Add(Escola escola)
        {
            using (SqlConnection con = new SqlConnection(conexao))
            {
                SqlCommand cmd = new SqlCommand("stp_Escola_Ins", con)
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 60
                };

                cmd.Parameters.AddWithValue("@NomeEscola", escola.NomeEscola);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public void Edit(Escola escola)
        {
            using (SqlConnection con = new SqlConnection(conexao))
            {
                SqlCommand cmd = new SqlCommand("stp_Escola_Upd", con)
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 60
                };

                cmd.Parameters.AddWithValue("@IdEscola", escola.IdEscola);
                cmd.Parameters.AddWithValue("@NomeEscola", escola.NomeEscola);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public void Delete(int? id)
        {
            using (SqlConnection con = new SqlConnection(conexao))
            {
                SqlCommand cmd = new SqlCommand("stp_Escola_Del", con)
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 60
                };

                cmd.Parameters.AddWithValue("@IdEscola", id);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
