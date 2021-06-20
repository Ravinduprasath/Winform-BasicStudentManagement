using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace Std
{   
    class acConnection
    {
     
       public static OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\\DB.mdb");
     
       OleDbCommand cmd = con.CreateCommand();

       public virtual void connect()
       {
           con.Open();
       }

       public virtual void close()
       {
           con.Close();
       }
    }
    class acConnectOne 
    {
        public static OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\\DB1.mdb");

        OleDbCommand cmd = con.CreateCommand();

        public virtual void connect()
        {
            con.Open();
        }

        public virtual void close()
        {
            con.Close();
        }
    }
}
