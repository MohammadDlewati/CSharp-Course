using System.Data;
using System.Data.SqlClient;

namespace SchoolPrj.BL
{
    class CLS_Users
    {
        DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
        public DataTable VerifiyUser(string Username, string Password)
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@UserName", SqlDbType.NVarChar, 100);
            param[0].Value = Username;
            param[1] = new SqlParameter("@Password", SqlDbType.NVarChar, 100);
            param[1].Value = Password;

            dal.Open();
            DataTable dt = dal.SelectData("VerifiyUser", param);
            dal.Close();
            return dt;
        }

        public DataTable AllUser()
        {
            dal.Open();
            DataTable dt = dal.SelectData("AllUser", null);
            dal.Close();
            return dt;
        }

        public void DeleteUser(int IdUser)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@IdUser", SqlDbType.Int);
            param[0].Value = IdUser;

            dal.Open();
            dal.ExecuteCommand("DelUser", param);
            dal.Close();
        }

        public void AddUser(string Username, string Password)
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@UserName", SqlDbType.NVarChar, 100);
            param[0].Value = Username;
            param[1] = new SqlParameter("@Password", SqlDbType.NVarChar, 100);
            param[1].Value = Password;

            dal.Open();
            dal.ExecuteCommand("AddUser", param);
            dal.Close();
        }

        public void EditUser(int IdUser, string Username, string Password)
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@UserName", SqlDbType.NVarChar, 100);
            param[0].Value = Username;
            param[1] = new SqlParameter("@Password", SqlDbType.NVarChar, 100);
            param[1].Value = Password;
            param[2] = new SqlParameter("@IdUser", SqlDbType.Int);
            param[2].Value = IdUser;
            dal.Open();
            dal.ExecuteCommand("EditUser", param);
            dal.Close();
        }
    }
}
