using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolPrj.BL
{
    class CLS_Subject
    {
        DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
        public DataTable VerifiySubject(string NameSubject)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@NameSubject", SqlDbType.NVarChar, 100);
            param[0].Value = NameSubject;
            
            dal.Open();
            DataTable dt = dal.SelectData("VerifiySubject", param);
            dal.Close();
            return dt;
        }
        public DataTable AllSubject()
        {
            dal.Open();
            DataTable dt = dal.SelectData("AllSubject", null);
            dal.Close();
            return dt;
        }

        public void DeleteSubject(int IdSubject)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@IdSubject", SqlDbType.Int);
            param[0].Value = IdSubject;

            dal.Open();
            dal.ExecuteCommand("DelSubject", param);
            dal.Close();
        }
        public void AddSubject(string NameSubject,int Mark,int LimtSuccess, int IdClass)
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@NameSubject", SqlDbType.NVarChar, 100);
            param[0].Value = NameSubject;            
            param[1] = new SqlParameter("@Mark", SqlDbType.Int);
            param[1].Value = Mark;
            param[2] = new SqlParameter("@LimtSuccess", SqlDbType.Int);
            param[2].Value = LimtSuccess;
            param[3] = new SqlParameter("@IdClass", SqlDbType.Int);
            param[3].Value = IdClass;

            dal.Open();
            dal.ExecuteCommand("AddSubject", param);
            dal.Close();
        }
        public string Sub_Class(int IdClass)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@IdClass", SqlDbType.Int);
            param[0].Value = IdClass;

            dal.Open();
            string Class = dal.SelectDataString("Sub_Class", param);
            dal.Close();

            return Class;
        }
        public int Sub_IdClass(string Class)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Class", SqlDbType.NVarChar, 100);
            param[0].Value = Class;

            dal.Open();
            int IdClass = dal.SelectDataInt("Sub_IdClass", param);
            dal.Close();

            return IdClass;
        }
        public void EditSubject(int IdSubject,string NameSubject, int Mark, int LimtSuccess)
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@IdSubject", SqlDbType.Int);
            param[0].Value = IdSubject;

            param[1] = new SqlParameter("@NameSubject", SqlDbType.NVarChar, 50);
            param[1].Value = NameSubject;

            param[2] = new SqlParameter("@’Mark", SqlDbType.Int);
            param[2].Value = Mark;

            param[3] = new SqlParameter("@LimtSuccess", SqlDbType.Int);
            param[3].Value = LimtSuccess;
            dal.Open();
            dal.ExecuteCommand("EditSubject", param);
            dal.Close();
        }
        public DataTable getSubjectForClass(int IdClass)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@IdClass", SqlDbType.Int);
            param[0].Value = IdClass;
            dal.Open();
            DataTable dt = dal.SelectData("getSubjectForClass", param);
            dal.Close();
            return dt;
        }
    }
}
