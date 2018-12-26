using System;
using System.Data;
using System.Windows.Forms;

namespace SchoolPrj
{
    public partial class Users : Form
    {
        BL.CLS_Users usr = new BL.CLS_Users();
        DataTable dt;
        public Users()
        {
            InitializeComponent();
            dt = usr.AllUser();
            cmbUser.DataSource = dt;
            cmbUser.ValueMember = "IdUser";
            cmbUser.DisplayMember = "UserName";
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            
            DataTable dt= usr.VerifiyUser(cmbUser.Text, txtPassword.Text);
            if(dt.Rows[0][0].ToString().Equals("0"))
            {
                MessageBox.Show("هناك خطأ في اسم المستخدم أو كلمة المرور");
            }
            else
            {
                PL.Menu mn = new PL.Menu();
                mn.ShowDialog();
            }
            
        }

        

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
