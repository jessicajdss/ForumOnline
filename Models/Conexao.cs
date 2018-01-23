using System.Data.SqlClient;

namespace ForumWebServices.Models
{


    public abstract class Conexao
    {
        protected SqlConnection con = null;

        protected SqlCommand cmd = null;

        protected SqlDataReader sdr = null;

        protected static string Caminho(){

            return @"Data Source = .\SqlExpress;Initial Catalog = Forum;user id=sa;password=senai@123";
            
        }

    }
}