using System.Data;
using System.Data.SqlClient;

namespace SchoolPrj.BL
{
    class CLS_Classes
    {
        DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
        public DataTable VerifiyClass(string Class)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Class", SqlDbType.NVarChar, 100);
            param[0].Value = Class;
            
            dal.Open();
            DataTable dt = dal.SelectData("VerifiyClass", param);
            dal.Close();
            return dt;
        }

        public DataTable AllClasses()
        {
            dal.Open();
            DataTable dt = dal.SelectData("AllClasses", null);
            dal.Close();
            return dt;
        }

        public void DeleteClass(int IdClass)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Id_Class", SqlDbType.Int);
            param[0].Value = IdClass;

            dal.Open();
            dal.ExecuteCommand("DelClass", param);
            dal.Close();
        }

        public void AddClass(string Class)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Class", SqlDbType.NVarChar, 100);
            param[0].Value = Class;
            

            dal.Open();
            dal.ExecuteCommand("AddClass", param);
            dal.Close();
        }

        public void EditClass(int Id_Class, string Class)
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@Class", SqlDbType.NVarChar, 100);
            param[0].Value = Class;
            
            param[1] = new SqlParameter("@Id_Class", SqlDbType.Int);
            param[1].Value = Id_Class;
            dal.Open();
            dal.ExecuteCommand("EditClass", param);
            dal.Close();
        }
    }
}
