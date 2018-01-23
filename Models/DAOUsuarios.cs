using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ForumWebServices.Models
{
    public class DAOUsuarios:Conexao
    {
        //SqlConnection con = null;
        //SqlCommand cmd = null;
        //SqlDataReader rd = null;

        //string conexao = @"Data Source = .\SqlExpress;Initial Catalog = Forum;user id=sa;password=senai@123";


        // public List<Usuario> ListarUsuarios()
        // {

        //     List<Usuario> usuarios = new List<Usuario>();

        //     try
        //     {
        //         con = new SqlConnection(conexao);
        //         con.Open();
        //         cmd = new SqlCommand();
        //         cmd.Connection = con;
        //         cmd.CommandType = CommandType.Text;
        //         cmd.CommandText = "Select * from tbUsuario";
        //         rd = cmd.ExecuteReader();

        //         while (rd.Read())
        //         {
        //             usuarios.Add(new Usuario()
        //             {
        //                 idUsuario = rd.GetInt32(0),
        //                 nomeUsuario = rd.GetString(1),
        //                 login = rd.GetString(2),
        //                 senha = rd.GetString(3),
        //                 dataCadastro = rd.GetDateTime(4)
        //             });
        //         }

        //     }
        //     catch (SqlException se)
        //     {
        //         throw new ConstraintException(se.Message);
        //     }
        //     catch (ConstraintException ex)
        //     {
        //         throw new ConstraintException(ex.Message);
        //     }
        //     finally
        //     {
        //         con.Close();
        //     }
        //     return usuarios;

        // }


        public List<Usuario> ListarUsuarios()
        {

            List<Usuario> usuarios = new List<Usuario>();

            try
            {
                con = new SqlConnection(Caminho());
                con.Open();
                cmd = new SqlCommand("Select * from tbUsuario",con);
                sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    usuarios.Add(new Usuario()
                    {
                        idUsuario = sdr.GetInt32(0),
                        nomeUsuario = sdr.GetString(1),
                        login = sdr.GetString(2),
                        senha = sdr.GetString(3),
                        dataCadastro = sdr.GetDateTime(4)
                    });
                }

            }
            catch (SqlException se)
            {
                throw new ConstraintException("Erro ao tentar ler a tabela de usuários -> "+se.Message);
            }
            catch (ConstraintException ex)
            {
                throw new ConstraintException("Erro inesperado -> "+ex.Message);
            }
            finally
            {
                con.Close();
            }
            return usuarios;

        }

        public bool Cadastro(Usuario usuarios)
        {
            bool resultado = false;
            try
            {
                con = new SqlConnection();                
                cmd = new SqlCommand();
                
                string inserir = "insert into tbUsuario(nomeUsuario,login,senha, dataCadastro) values (@n,@l,@s,@d)";
                cmd.Parameters.AddWithValue("@n", usuarios.nomeUsuario);
                cmd.Parameters.AddWithValue("@l", usuarios.login);
                cmd.Parameters.AddWithValue("@s", usuarios.senha);
                cmd.Parameters.AddWithValue("@d", System.DateTime.Now);

                con.ConnectionString=Caminho();
                con.Open();
                cmd.Connection = con;

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = inserir;
                
                int r = cmd.ExecuteNonQuery();
                if (r > 0)
                    resultado = true;

                cmd.Parameters.Clear();
            }
            catch (SqlException se)
            {
                throw new ConstraintException("Erro ao cadastrar -> "+se.Message);
            }
            catch (ConstraintException ex)
            {
                throw new ConstraintException("Erro inesperado ->" + ex.Message);
            }
            finally
            {
                con.Close();
            }

            return resultado;
        }

        public bool Editar(Usuario usuarios)
        {
            bool resultado = false;
            try
            {
                con = new SqlConnection();                
                cmd = new SqlCommand();
                
                string atualizar = "update tbUsuario set nomeUsuario = @n, login = @l, senha = @s," + 
                "dataCadastro=@d where idUsuario = @id";
                cmd.Parameters.AddWithValue("@id", usuarios.idUsuario);
                cmd.Parameters.AddWithValue("@n", usuarios.nomeUsuario);
                cmd.Parameters.AddWithValue("@l", usuarios.login);
                cmd.Parameters.AddWithValue("@s", usuarios.senha);
                cmd.Parameters.AddWithValue("@d", System.DateTime.Now);

                con.ConnectionString=Caminho();
                con.Open();
                cmd.Connection = con;

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = atualizar;

                int r = cmd.ExecuteNonQuery();
                if (r > 0)
                    resultado = true;

                cmd.Parameters.Clear();
            }
            catch (SqlException se)
            {
                throw new ConstraintException("Erro ao tentar atualizar -> "+se.Message);
            }
            catch (ConstraintException ex)
            {
                throw new ConstraintException("Erro inesperado -> "+ex.Message);
            }
            finally
            {
                con.Close();
            }

            return resultado;
        }

        public bool Apagar(int id)
        {
             bool resultado = false;
            try
            {
                con = new SqlConnection();                
                cmd = new SqlCommand();
                
                string apagar = "delete from tbUsuario where idUsuario = @id";
                cmd.Parameters.AddWithValue("@id",id);


                con.ConnectionString=Caminho();
                con.Open();
                cmd.Connection = con;

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = apagar;

                int r = cmd.ExecuteNonQuery();
                if (r > 0)
                    resultado = true;

                cmd.Parameters.Clear();
            }
            catch (SqlException se)
            {
                throw new ConstraintException("Erro ao tentar apagar -> "+se.Message);
            }
            catch (ConstraintException ex)
            {
                throw new ConstraintException("Erro inesperado -> "+ex.Message);
            }
            finally
            {
                con.Close();
            }

            return resultado;
        }
    }
}