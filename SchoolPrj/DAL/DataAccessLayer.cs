using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;

namespace SchoolPrj.DAL
{
    class DataAccessLayer
    {
        
        private string connectionString = "";
        private SqlConnection sqlConnection;
        public DataAccessLayer()
        {

            //string ServerName = @"DESKTOP-1805VJI\SQLEXPRESS";
            string ServerName = @".\SQLEXPRESS";
            string dataBase = "SchoolDB";            
            connectionString = @"Server=" + ServerName + "; DataBase=" + dataBase + "; Integrated Security = true";
            sqlConnection = new SqlConnection(connectionString);
        }
        public void Open()
        {
            if (sqlConnection.State != ConnectionState.Open)
            {
                sqlConnection.Open();
            }
        }
        public void Close()
        {
            if (sqlConnection.State == ConnectionState.Open)
            {
                sqlConnection.Close();
            }
        }
        public DataTable SelectData(string storedProcedure, SqlParameter[] param)
        {
            DataTable dt = new DataTable();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = storedProcedure;
            if (param != null)
            {
                sqlCommand.Parameters.AddRange(param);
            }
            SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
            da.Fill(dt);
            return dt;
        }

        public SqlDataAdapter SelectDataGetAdpat(string storedProcedure, SqlParameter[] param)
        {
            DataTable dt = new DataTable();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = storedProcedure;
            if (param != null)
            {
                sqlCommand.Parameters.AddRange(param);
            }
            SqlDataAdapter da = new SqlDataAdapter(sqlCommand);

            return da;
        }

        internal int SelectDataInt(string storedProcedure)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = storedProcedure;

            Open();
            int id = Convert.ToInt16(sqlCommand.ExecuteScalar());
            Close();
            return id;
        }

        public Image SelectDataImage(string storedProcedure, SqlParameter[] param)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = storedProcedure;
            if (param != null)
            {
                sqlCommand.Parameters.AddRange(param);
            }
            Byte[] imBytes = (Byte[])sqlCommand.ExecuteScalar();
            MemoryStream ms = new MemoryStream(imBytes);
            return Image.FromStream(ms);
        }

        public string SelectDataString(string storedProcedure, SqlParameter[] param)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = storedProcedure;
            if (param != null)
            {
                sqlCommand.Parameters.AddRange(param);
            }

            return sqlCommand.ExecuteScalar().ToString();
        }

        public void ExecuteCommand(string storedProcedure, SqlParameter[] param)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = storedProcedure;
            if (param != null)
            {
                sqlCommand.Parameters.AddRange(param);
            }
            Open();
            sqlCommand.ExecuteNonQuery();
            Close();
        }
    }
}
