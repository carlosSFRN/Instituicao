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
    public class AlunoNotaPorTurmaRepository : IAlunoNotaPorTurmaRepository
    {
        private readonly string conexao = DbContext.GetConnection();

        public IEnumerable<AlunoNotaPorTurma> GetAlunoNotaPorTurmas(int? id)
        {
            List<AlunoNotaPorTurma> listaAlunoNotaPorTurma = new List<AlunoNotaPorTurma>();

            using (SqlConnection con = new SqlConnection(conexao))
            {
                SqlCommand cmd = new SqlCommand("stp_Turma_Sel", con)
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 60
                };

                cmd.Parameters.AddWithValue("@IdTurma", id);
                cmd.Parameters.AddWithValue("@TipoConsulta", "ListarAlunoNotasPorTurma");

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    AlunoNotaPorTurma alunoNotaPorTurma = new AlunoNotaPorTurma
                    {
                        IdTurma = Convert.ToInt32(rdr["IdTurma"]),
                        NomeTurma = rdr["NomeTurma"].ToString(),
                        NomeAluno = rdr["NomeAluno"].ToString(),
                        NotaAluno = Convert.ToDecimal(rdr["NotaAluno"])
                    };

                    listaAlunoNotaPorTurma.Add(alunoNotaPorTurma);
                }
                con.Close();
            }
            return listaAlunoNotaPorTurma;
        }
    }
}
