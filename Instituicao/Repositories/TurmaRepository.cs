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
    public class TurmaRepository : ITurmaRepository
    {
        private readonly string conexao = DbContext.GetConnection();

        public IEnumerable<Turma> GetAll()
        {
            List<Turma> listaTurma = new List<Turma>();

            using (SqlConnection con = new SqlConnection(conexao))
            {
                SqlCommand cmd = new SqlCommand("stp_Turma_Sel", con)
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 60
                };

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Turma escola = new Turma
                    {
                        IdTurma = Convert.ToInt32(rdr["IdTurma"]),
                        NomeTurma = rdr["NomeTurma"].ToString(),
                        EscolaId = Convert.ToInt32(rdr["EscolaId"])
                    };

                    listaTurma.Add(escola);
                }
                con.Close();
            }
            return listaTurma;

        }

        public Turma GetPorId(int? id)
        {
            Turma turma = new Turma();

            using (SqlConnection con = new SqlConnection(conexao))
            {
                SqlCommand cmd = new SqlCommand("stp_Turma_Sel", con)
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 60
                };

                cmd.Parameters.AddWithValue("@IdTurma", id);
                cmd.Parameters.AddWithValue("@TipoConsulta", "PorId"); 

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    turma.IdTurma = Convert.ToInt32(rdr["IdTurma"]);
                    turma.NomeTurma = rdr["NomeTurma"].ToString();
                    turma.EscolaId = Convert.ToInt32(rdr["EscolaId"]);
                }
            }
            return turma;
        }
        public void Add(Turma turma)
        {
            using (SqlConnection con = new SqlConnection(conexao))
            {
                SqlCommand cmd = new SqlCommand("stp_Turma_Ins", con)
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 60
                };

                cmd.Parameters.AddWithValue("@NomeTurma", turma.NomeTurma);
                cmd.Parameters.AddWithValue("@EscolaId", turma.EscolaId);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public void Edit(Turma turma)
        {
            using (SqlConnection con = new SqlConnection(conexao))
            {
                SqlCommand cmd = new SqlCommand("stp_Turma_Upd", con)
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 60
                };

                cmd.Parameters.AddWithValue("@IdTurma", turma.IdTurma);
                cmd.Parameters.AddWithValue("@NomeTurma", turma.NomeTurma);
                cmd.Parameters.AddWithValue("@EscolaId", turma.EscolaId);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public void Delete(int? id)
        {
            using (SqlConnection con = new SqlConnection(conexao))
            {
                SqlCommand cmd = new SqlCommand("stp_Turma_Del", con)
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 60
                };

                cmd.Parameters.AddWithValue("@IdTurma", id);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
