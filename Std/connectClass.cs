using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Std
{
  /* public class connectClass
    {   
        public static string ConnectionString = (@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\stdDB.mdf;Integrated Security=True");
        public static SqlConnection con;
        public void connect() 
        {
            con = new SqlConnection(ConnectionString);
            con.Open();
        }

        public void close()
        {
            con.Close();
        }
        
     /*   public void ExecuteQueries(string Query_)
        {
            SqlCommand cmd = new SqlCommand(Query_, con);
            con.Open();
            cmd.ExecuteNonQuery();
        }


        public SqlDataReader DataReader(string Query_)
        {
            SqlCommand cmd = new SqlCommand(Query_, con);
            SqlDataReader dr = cmd.ExecuteReader();
            return dr;
        } 
            
    }*/
}
