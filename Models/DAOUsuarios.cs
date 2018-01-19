using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ForumWebServices.Models
{
    public class DAOUsuarios
    {
        SqlConnection con = null;
        SqlCommand cmd = null;
        SqlDataReader rd = null;

        string conexao = @"Data Source = .\SqlExpress;Initial Catalog = Forum;user id=sa;password=senai@123";


        public List<Usuario> ListarUsuarios()
        {

            List<Usuario> usuarios = new List<Usuario>();

            try
            {
                con = new SqlConnection(conexao);
                con.Open();
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select * from tbUsuario";
                rd = cmd.ExecuteReader();

                while (rd.Read())
                {
                    usuarios.Add(new Usuario()
                    {
                        idUsuario = rd.GetInt32(0),
                        nomeUsuario = rd.GetString(1),
                        login = rd.GetString(2),
                        senha = rd.GetString(3),
                        dataCadastro = rd.GetDateTime(4)
                    });
                }

            }
            catch (SqlException se)
            {
                throw new ConstraintException(se.Message);
            }
            catch (ConstraintException ex)
            {
                throw new ConstraintException(ex.Message);
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
                con = new SqlConnection(conexao);
                con.Open();
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into tbUsuario(nomeUsuario,login,senha, dataCadastro) values (@n,@l,@s,@d)";
                cmd.Parameters.AddWithValue("@n", usuarios.nomeUsuario);
                cmd.Parameters.AddWithValue("@l", usuarios.login);
                cmd.Parameters.AddWithValue("@s", usuarios.senha);
                cmd.Parameters.AddWithValue("@d", usuarios.dataCadastro);


                int r = cmd.ExecuteNonQuery();
                if (r > 0)
                    resultado = true;

                cmd.Parameters.Clear();
            }
            catch (SqlException se)
            {
                throw new ConstraintException("Erro SQL -> "+se.Message);
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

        // public bool Editar(Usuario usuarios)
        // {
        //     bool resultado = false;
        //     try
        //     {
        //         con = new SqlConnection(conexao);
        //         con.Open();
        //         cmd = new SqlCommand();
        //         cmd.Connection = con;
        //         cmd.CommandType = CommandType.Text;
        //         cmd.CommandText = "update tbUsuario set nomeUsuario = @n, login = @l, senha = @s where idUsuario = @id";
        //         cmd.Parameters.AddWithValue("@id", usuarios.idUsuario);
        //         cmd.Parameters.AddWithValue("@n", usuarios.nomeUsuario);
        //         cmd.Parameters.AddWithValue("@l", usuarios.login);
        //         cmd.Parameters.AddWithValue("@s", usuarios.senha);

        //         int r = cmd.ExecuteNonQuery();
        //         if (r > 0)
        //             resultado = true;

        //         cmd.Parameters.Clear();
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

        //     return resultado;
        // }

        // public bool Apagar(int id)
        // {
        //     bool resultado = false;
        //     try
        //     {
        //         con = new SqlConnection(conexao);
        //         con.Open();
        //         cmd = new SqlCommand();
        //         cmd.CommandType = CommandType.Text;
        //         cmd.CommandText = "delete from Cidades where Id = @id";
        //         cmd.Parameters.AddWithValue("@id", id);

        //         int r = cmd.ExecuteNonQuery();
        //         if (r > 0)
        //             resultado = true;

        //         cmd.Parameters.Clear();
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

        //     return resultado;
        // }   
    }
}