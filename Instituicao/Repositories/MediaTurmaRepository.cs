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
    public class MediaTurmaRepository : IMediaTurmaRepository
    {
        private readonly string conexao = DbContext.GetConnection();

        public IEnumerable<MediaTurma> GetTurmaMediaPorId(int? id)
        {
            List<MediaTurma> listamediaTurma = new List<MediaTurma>();

            using (SqlConnection con = new SqlConnection(conexao))
            {
                SqlCommand cmd = new SqlCommand("stp_Turma_Sel", con)
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 60
                };

                cmd.Parameters.AddWithValue("@IdTurma", id);
                cmd.Parameters.AddWithValue("@TipoConsulta", "MediaPorIdTurma");

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    MediaTurma mediaTurma = new MediaTurma
                    {
                        IdTurma = Convert.ToInt32(rdr["IdTurma"]),
                        NomeTurma = rdr["NomeTurma"].ToString(),
                        NotaMedia = Convert.ToDecimal(rdr["NotaMedia"])
                    };

                    listamediaTurma.Add(mediaTurma);
                }
                con.Close();
            }
            return listamediaTurma;
        }
    }
}
