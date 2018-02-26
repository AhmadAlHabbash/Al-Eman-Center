using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Tahfiz.classes
{
    public class Model
    {
        //
        // Veriables
        //
        private static Model instance;
        private const string strAccessConn = "Provider=Microsoft.ACE.OLEDB.12.0;" +
            "Data Source=D:\\AlEmanDB.accdb;Jet OLEDB:Database Password = 123456;";
        private OleDbConnection conn;
        private OleDbCommand cmd;

        //
        // Constructor and Initialaization
        //
        private Model()
        {
            conn = new OleDbConnection(strAccessConn);
            conn.Open();
            cmd = new OleDbCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
        }
        public static Model getInstance()
        {
            if (instance == null)
            {
                instance = new Model();
            }
            return instance;
        }

        //
        // Password Hashing "one way"
        //
        public string getMD5(string pass)
        {
            StringBuilder sBuilder = new StringBuilder();
            using (MD5 md5Hash = MD5.Create())
            {
                byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(pass));
                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }
            }
            return sBuilder.ToString();
        }

        //
        // Log-In
        //
        public User login(string username, string password)
        {
            User user = null;
            cmd.CommandText = String.Format("SELECT ID, Username FROM USERS WHERE Username='{0}' and Password='{1}';",
                username, getMD5(password));

            OleDbDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                user = new User(dr.GetString(0), dr.GetString(1));
            }
            dr.Close();

            return user;
        }
    }
}
