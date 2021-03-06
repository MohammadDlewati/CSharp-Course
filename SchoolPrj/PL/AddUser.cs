﻿using System;
using System.Data;
using System.Windows.Forms;

namespace SchoolPrj.PL
{
    public partial class AddUser : Form
    {
        public AddUser()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            BL.CLS_Users usr = new BL.CLS_Users();
            DataTable dt = usr.VerifiyAddUser(txtUserName.Text);
            if (dt.Rows[0][0].ToString().Equals("0"))
            {
                usr.AddUser(txtUserName.Text, txtPassword.Text);
                DialogResult result = MessageBox.Show("تم الحفظ. هل تريد إضافة مستخدم جديد؟", "حفظ", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    txtUserName.Text = "";
                    txtPassword.Text = "";
                }
                else
                    Close();
            }
            else
                MessageBox.Show("الاسم موجود مسبقاً");
        }
    }
}
