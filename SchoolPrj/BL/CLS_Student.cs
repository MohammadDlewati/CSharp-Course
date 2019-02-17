using System;
using System.Data;
using System.Data.SqlClient;

namespace SchoolPrj.BL
{
    class CLS_Student
    {
        DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
        public DataTable VerifiyStudent(string NameStudent)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@NameStudent", SqlDbType.NVarChar, 100);
            param[0].Value = NameStudent;

            dal.Open();
            DataTable dt = dal.SelectData("VerifiyStudent", param);
            dal.Close();
            return dt;
        }
        public void AddStudent(string NameStudent, string AdressStudent, string TelphoneStudent, string MobilePhoneStudent, string BirthDay, string GenderStudent, string EmailStudent, byte[] ImageStudent, string NoteStudent)
        {
            SqlParameter[] param = new SqlParameter[9];
            param[0] = new SqlParameter("@NameStudent", SqlDbType.NVarChar, 100);
            param[0].Value = NameStudent;
            param[1] = new SqlParameter("@AdressStudent", SqlDbType.NVarChar, 100);
            param[1].Value = AdressStudent;
            param[2] = new SqlParameter("@TelphoneStudent", SqlDbType.NVarChar, 100);
            param[2].Value = TelphoneStudent;
            param[3] = new SqlParameter("@MobilePhoneStudent", SqlDbType.NVarChar, 100);
            param[3].Value = MobilePhoneStudent;
            param[4] = new SqlParameter("@BirthDay", SqlDbType.Date);
            param[4].Value = BirthDay;
            param[5] = new SqlParameter("@GenderStudent", SqlDbType.NVarChar,50);
            param[5].Value = GenderStudent;
            param[6] = new SqlParameter("@EmailStudent", SqlDbType.NVarChar, 100);
            param[6].Value = EmailStudent;
            param[7] = new SqlParameter("@ImageStudent", SqlDbType.Image);
            param[7].Value = ImageStudent;
            param[8] = new SqlParameter("@NoteStudent", SqlDbType.NVarChar, 500);
            param[8].Value = NoteStudent;
            
            dal.Open();
            dal.ExecuteCommand("AddStudent", param);
            dal.Close();
        }
        public void EditStudent(int IdStudent, string NameStudent, string AdressStudent, string TelphoneStudent, string MobilePhoneStudent, string BirthDay, string GenderStudent, string EmailStudent, byte[] ImageStudent, string NoteStudent)
        {
            SqlParameter[] param = new SqlParameter[10];
            param[0] = new SqlParameter("@IdStudent", SqlDbType.Int);
            param[0].Value = IdStudent;
            param[1] = new SqlParameter("@NameStudent", SqlDbType.NVarChar, 100);
            param[1].Value = NameStudent;
            param[2] = new SqlParameter("@AdressStudent", SqlDbType.NVarChar, 100);
            param[2].Value = AdressStudent;
            param[3] = new SqlParameter("@TelphoneStudent", SqlDbType.NVarChar, 100);
            param[3].Value = TelphoneStudent;
            param[4] = new SqlParameter("@MobilePhoneStudent", SqlDbType.NVarChar, 100);
            param[4].Value = MobilePhoneStudent;
            param[5] = new SqlParameter("@BirthDay", SqlDbType.Date);
            param[5].Value = BirthDay;
            param[6] = new SqlParameter("@GenderStudent", SqlDbType.NVarChar,50);
            param[6].Value = GenderStudent;
            param[7] = new SqlParameter("@EmailStudent", SqlDbType.NVarChar, 100);
            param[7].Value = EmailStudent;
            param[8] = new SqlParameter("@ImageStudent", SqlDbType.Image);
            param[8].Value = ImageStudent;
            param[9] = new SqlParameter("@NoteStudent", SqlDbType.NVarChar, 500);
            param[9].Value = NoteStudent;
            
            dal.Open();
            dal.ExecuteCommand("EditStudent", param);
            dal.Close();
        }
        public void DelStudent(int IdStudent)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@IdStudent", SqlDbType.Int);
            param[0].Value = IdStudent;
            dal.Open();
            dal.ExecuteCommand("DelStudent", param);
            dal.Close();
        }
        public DataTable AllStudent()
        {
            dal.Open();
            DataTable dt = dal.SelectData("AllStudent", null);
            dal.Close();
            return dt;
        }

        public DataTable GetStudent(int IdStudent)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@IdStudent", SqlDbType.Int);
            param[0].Value = IdStudent;
            dal.Open();
            DataTable dt = dal.SelectData("GetStudent_from_Id", param);
            dal.Close();
            return dt;
        }
        public DataTable SearchStudent(String StrSearch)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@StrSearch", SqlDbType.NVarChar, 100);
            param[0].Value = StrSearch;
            dal.Open();
            DataTable dt = dal.SelectData("SearchStudent", param);
            dal.Close();
            return dt;
        }
        public DataTable AllSalStdBetweenDate(String first, String last)
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@first", SqlDbType.Date);
            param[0].Value = first;
            param[1] = new SqlParameter("@last", SqlDbType.Date);
            param[1].Value = last;
            dal.Open();
            DataTable dt = dal.SelectData("AllSalStdBetweenDate", param);
            dal.Close();
            return dt;
        }

    }
}
