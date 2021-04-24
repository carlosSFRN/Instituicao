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
    public class AlunoRepository : IAlunoRepository
    {
        private readonly string conexao = DbContext.GetConnection();

        public IEnumerable<Aluno> GetAll()
        {
            List<Aluno> listaAluno = new List<Aluno>();

            using (SqlConnection con = new SqlConnection(conexao))
            {
                SqlCommand cmd = new SqlCommand("stp_Aluno_Sel", con)
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 60
                };

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Aluno escola = new Aluno
                    {
                        IdAluno = Convert.ToInt32(rdr["IdAluno"]),
                        NomeAluno = rdr["NomeAluno"].ToString(),
                        Nota = Convert.ToDecimal(rdr["Nota"]),
                        TurmaId = Convert.ToInt32(rdr["TurmaId"])
                    };

                    listaAluno.Add(escola);
                }
                con.Close();
            }
            return listaAluno;

        }
        public Aluno GetPorId(int? id)
        {
            Aluno aluno = new Aluno();

            using (SqlConnection con = new SqlConnection(conexao))
            {
                SqlCommand cmd = new SqlCommand("stp_Aluno_Sel", con)
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 60
                };

                cmd.Parameters.AddWithValue("@IdAluno", id);
                cmd.Parameters.AddWithValue("@TipoConsulta", "PorId");

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    aluno.IdAluno = Convert.ToInt32(rdr["IdAluno"]);
                    aluno.NomeAluno = rdr["NomeAluno"].ToString();
                    aluno.Nota = Convert.ToDecimal(rdr["Nota"]);
                    aluno.TurmaId = Convert.ToInt32(rdr["TurmaId"]);
                }
            }
            return aluno;
        }
        public void Add(Aluno aluno)
        {
            using (SqlConnection con = new SqlConnection(conexao))
            {
                SqlCommand cmd = new SqlCommand("stp_Aluno_Ins", con)
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 60
                };

                cmd.Parameters.AddWithValue("@NomeAluno", aluno.NomeAluno);
                cmd.Parameters.AddWithValue("@Nota", aluno.Nota);
                cmd.Parameters.AddWithValue("@TurmaId", aluno.TurmaId);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public void Edit(Aluno aluno)
        {
            using (SqlConnection con = new SqlConnection(conexao))
            {
                SqlCommand cmd = new SqlCommand("stp_Aluno_Upd", con)
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 60
                };

                cmd.Parameters.AddWithValue("@IdAluno", aluno.IdAluno);
                cmd.Parameters.AddWithValue("@NomeAluno", aluno.NomeAluno);
                cmd.Parameters.AddWithValue("@Nota", aluno.Nota);
                cmd.Parameters.AddWithValue("@TurmaId", aluno.TurmaId);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public void Delete(int? id)
        {
            using (SqlConnection con = new SqlConnection(conexao))
            {
                SqlCommand cmd = new SqlCommand("stp_Aluno_Del", con)
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 60
                };

                cmd.Parameters.AddWithValue("@IdAluno", id);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
