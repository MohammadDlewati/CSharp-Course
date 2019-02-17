using System;
using System.Data;
using System.Data.SqlClient;

namespace SchoolPrj.BL
{
    class CLS_RegStudent
    {
        DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
        public DataTable VerifiyRegStudent(string NameStudent)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@NameStudent", SqlDbType.NVarChar, 100);
            param[0].Value = NameStudent;

            dal.Open();
            DataTable dt = dal.SelectData("VerifiyRegStudent", param);
            dal.Close();
            return dt;
        }
        public void AddRegStudent(int IdStudent, string NameStudent, int IdClass, int Id_Division, string DateReg)
        {
            SqlParameter[] param = new SqlParameter[5]; 
            param[0] = new SqlParameter("@IdStudent", SqlDbType.Int);
            param[0].Value = IdStudent;
            param[1] = new SqlParameter("@NameStudent", SqlDbType.NVarChar, 100);
            param[1].Value = NameStudent;
            param[2] = new SqlParameter("@IdClass", SqlDbType.Int);
            param[2].Value = IdClass;
            param[3] = new SqlParameter("@Id_Division", SqlDbType.NVarChar, 100);
            param[3].Value = Id_Division;
            param[4] = new SqlParameter("@DateReg", SqlDbType.Date);
            param[4].Value = DateReg;            
            dal.Open();
            dal.ExecuteCommand("AddRegStudents", param);
            dal.Close();
        }
        public DataTable AllRegStudent()
        {
            dal.Open();
            DataTable dt = dal.SelectData("AllRegStudents", null);
            dal.Close();
            return dt;
        }
        public DataTable AllStudentAtClass(int IdClass)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@IdClass", SqlDbType.NVarChar, 100);
            param[0].Value = IdClass;
            dal.Open();
            DataTable dt = dal.SelectData("AllStudentAtClass", param);
            dal.Close();
            return dt;
        }
        public DataTable SearchRegStudent(string StrSearch)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@StrSearch", SqlDbType.NVarChar, 500);
            param[0].Value = StrSearch;
            dal.Open();
            DataTable dt = dal.SelectData("SearchRegStudent", param);
            dal.Close();
            return dt;
        }
        public void DelReg(int IdStudent, int IdRegStudent)
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@IdStudent", SqlDbType.Int);
            param[0].Value = IdStudent;
            param[1] = new SqlParameter("@IdRegStudent", SqlDbType.Int);
            param[1].Value = IdRegStudent;
            dal.Open();
            dal.ExecuteCommand("DelReg", param);
            dal.Close();
        }
        public void AddSubForReg(int IdReg, int IdSubject, String NameSubject)
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@IdReg", SqlDbType.Int);
            param[0].Value = IdReg;
            param[1] = new SqlParameter("@IdSubject", SqlDbType.Int);
            param[1].Value = IdSubject;
            param[2] = new SqlParameter("@NameSubject", SqlDbType.NVarChar, 100);
            param[2].Value = NameSubject;
            dal.Open();
            dal.ExecuteCommand("AddSubReg", param);
            dal.Close();
        }
        public void DelSubForReg(int IdReg)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@IdReg", SqlDbType.Int);
            param[0].Value = IdReg;
            dal.Open();
            dal.ExecuteCommand("DelSubReg", param);
            dal.Close();
        }
        public DataTable AllSubForReg(int IdReg)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@IdReg", SqlDbType.Int);
            param[0].Value = IdReg;
            dal.Open();
            DataTable dt = dal.SelectData("AllSubReg", param);
            dal.Close();
            return dt;
        }
        public void EditRegStudent(int IdRegStudent, int IdStudent, string NameStudent, int IdClass, int Id_Division, string DateReg )
        {
            SqlParameter[] param = new SqlParameter[6];
            param[0] = new SqlParameter("@IdRegStudent", SqlDbType.Int);
            param[0].Value = IdRegStudent;
            param[1] = new SqlParameter("@IdStudent", SqlDbType.Int);
            param[1].Value = IdStudent;
            param[2] = new SqlParameter("@NameStudent", SqlDbType.NVarChar, 100);
            param[2].Value = NameStudent;
            param[3] = new SqlParameter("@IdClass", SqlDbType.Int);
            param[3].Value = IdClass;
            param[4] = new SqlParameter("@Id_Division", SqlDbType.NVarChar, 100);
            param[4].Value = Id_Division;
            param[5] = new SqlParameter("@DateReg", SqlDbType.Date);
            param[5].Value = DateReg;
            
            dal.Open();
            dal.ExecuteCommand("EditRegStudent", param);
            dal.Close();
        }

        public DataTable GetRegStudent(int IdStudent)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@IdStudent", SqlDbType.Int);
            param[0].Value = IdStudent;
            dal.Open();
            DataTable dt = dal.SelectData("GetRegStudent", param);
            dal.Close();
            return dt;
        }
    }
}
