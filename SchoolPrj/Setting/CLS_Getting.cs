using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolPrj.Setting
{
    class CLS_Getting
    {
        DAL.DataAccessLayer dal = new DAL.DataAccessLayer();

        public string Get_Class(int IdClass)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@IdClass", SqlDbType.Int);
            param[0].Value = IdClass;

            dal.Open();
            string Class = dal.SelectDataString("Get_Class", param);
            dal.Close();

            return Class;
        }

        public string Get_Division(int IdDivision)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@IdDivision", SqlDbType.Int);
            param[0].Value = IdDivision;

            dal.Open();
            string Division = dal.SelectDataString("Get_Division", param);
            dal.Close();

            return Division;
        }
        public int Get_IdClass(string Class)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Class", SqlDbType.NVarChar, 100);
            param[0].Value = Class;

            dal.Open();
            int IdClass = dal.SelectDataInt("Get_IdClass", param);
            dal.Close();

            return IdClass;
        }

        public int Get_IdDivision(string Division)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Division", SqlDbType.NVarChar, 100);
            param[0].Value = Division;

            dal.Open();
            int IdDivision = dal.SelectDataInt("Get_IdDivision", param);
            dal.Close();

            return IdDivision;
        }

        public int Get_numLastRecored()
        {
            dal.Open();
            int IdStudent = dal.SelectDataInt("numLastRecored", null);
            dal.Close();

            return IdStudent;
        }
    }
}
