using System;
using System.Windows.Forms;

namespace SchoolPrj.PL
{
    public partial class EditUser : Form
    {
        int id;
        public EditUser(int IdUser,string Username,string Password)
        {
            InitializeComponent();
            txtUserName.Text = Username;
            txtPassword.Text = Password;
            id = IdUser;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            BL.CLS_Users usr = new BL.CLS_Users();
            usr.EditUser(id, txtUserName.Text, txtPassword.Text);
            Close();
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
