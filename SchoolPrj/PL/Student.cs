using System;
using System.Data;
using System.Windows.Forms;

namespace SchoolPrj.PL
{
    public partial class Student : Form
    {
        public Student()
        {
            InitializeComponent();
            this.RefreshTable();
            dtg.Columns[0].HeaderText = "رقم الطالب";
            dtg.Columns[1].HeaderText = "رقم السجل";
            dtg.Columns[2].HeaderText = "اسم الطالب";
            dtg.Columns[3].HeaderText = " الصف";
            dtg.Columns[4].HeaderText = " الشعبة";
            dtg.Columns[5].HeaderText = "تاريخ التسجيل";
        }

        public void RefreshTable()
        {
            BL.CLS_RegStudent stu = new BL.CLS_RegStudent();
            DataTable dt = stu.AllRegStudent();
            dtg.DataSource = dt;
        }

        private void btnRegStudent_Click(object sender, EventArgs e)
        {            
            AddEditStudent rst = new AddEditStudent("Add",0,"","","","","","","",null , "");
            rst.ShowDialog();
            this.RefreshTable();
        }

        

        private void Student_Load(object sender, EventArgs e)
        {
            RefreshTable();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            BL.CLS_RegStudent rstd = new BL.CLS_RegStudent();
            DataTable dt = rstd.SearchRegStudent(txtSearch.Text);
            dtg.DataSource = dt;
        }

        private void btnEditStudent_Click(object sender, EventArgs e)
        {
            AddEditStudent rst = new AddEditStudent("Edit", Int32.Parse(dtg.CurrentRow.Cells[1].Value.ToString()), dtg.CurrentRow.Cells[2].Value.ToString(), "", "", "", "", "", "", null, "");
            rst.ShowDialog();
            this.RefreshTable();
        }
    }
}
