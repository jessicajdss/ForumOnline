using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ForumWebServices.Models
{
    public class DAOTopicos:Conexao
    {
        public List<Topico> ListarTopicos()
        {

            List<Topico> topicos = new List<Topico>();

            try
            {
                con = new SqlConnection(Caminho());
                con.Open();
                cmd = new SqlCommand("Select * from tbTopico",con);
                sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    topicos.Add(new Topico()
                    {
                        idTopico = sdr.GetInt32(0),
                        titulo = sdr.GetString(1),
                        descricao = sdr.GetString(2),
                        dataCadTopico = sdr.GetDateTime(3)
                    });
                }

            }
            catch (SqlException se)
            {
                throw new ConstraintException("Erro ao tentar ler a tabela de tópicos -> "+se.Message);
            }
            catch (ConstraintException ex)
            {
                throw new ConstraintException("Erro inesperado -> "+ex.Message);
            }
            finally
            {
                con.Close();
            }
            return topicos;

        }
    }
}