using System.Data;
using System.Data.SqlClient;

namespace SchoolPrj.BL
{
    class CLS_Division
    {
        DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
        public DataTable VerifiyDivision(string Division,string IdClass)
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@Division", SqlDbType.NVarChar, 100);
            param[0].Value = Division;
            param[1] = new SqlParameter("@Class", SqlDbType.NVarChar,100);
            param[1].Value = IdClass;
            dal.Open();
            DataTable dt = dal.SelectData("VerifiyDivision", param);
            dal.Close();
            return dt;
        }

        public DataTable AllDivision()
        {
            dal.Open();
            DataTable dt = dal.SelectData("AllDivision", null);
            dal.Close();
            return dt;
        }

        public void DeleteDivision(int IdDivision)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@IdDivision", SqlDbType.Int);
            param[0].Value = IdDivision;

            dal.Open();
            dal.ExecuteCommand("DelDivision", param);
            dal.Close();
        }

        public void AddDivision(string Division,string IdClass)
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@Division", SqlDbType.NVarChar, 100);
            param[0].Value = Division;
            param[1] = new SqlParameter("@Class", SqlDbType.NVarChar, 100);
            param[1].Value = IdClass;

            dal.Open();
            dal.ExecuteCommand("AddDivision", param);
            dal.Close();
        }
        public string Div_Class(int IdClass)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@IdClass", SqlDbType.Int);
            param[0].Value = IdClass;

            dal.Open();
            string Class =dal.SelectDataString("Div_Class", param);
            dal.Close();

            return Class;
        }

        public int Div_IdClass(string Class)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Class", SqlDbType.NVarChar,100);
            param[0].Value = Class;

            dal.Open();
            int IdClass = dal.SelectDataInt("Div_IdClass", param);
            dal.Close();

            return IdClass;
        }
        public void EditDivision(int IdDivision, string Division, int IdClass)
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@Division", SqlDbType.NVarChar, 100);
            param[0].Value = Division;

            param[1] = new SqlParameter("@IdDivision", SqlDbType.Int);
            param[1].Value = IdDivision;

            param[2] = new SqlParameter("@IdClass", SqlDbType.Int);
            param[2].Value = IdClass;
            dal.Open();
            dal.ExecuteCommand("EditDivision", param);
            dal.Close();
        }
    }
}
