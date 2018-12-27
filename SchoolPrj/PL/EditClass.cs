using System;
using System.Data;
using System.Windows.Forms;

namespace SchoolPrj.PL
{
    public partial class EditClass : Form
    {
        int id;
        public EditClass(int Id_Class,string Class)
        {
            InitializeComponent();
            txtClassName.Text = Class;
            id = Id_Class;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            BL.CLS_Classes cla = new BL.CLS_Classes();
            DataTable dt = cla.VerifiyClass(txtClassName.Text);
            if (dt.Rows[0][0].ToString().Equals("0"))
            {
                cla.EditClass(id, txtClassName.Text);
                Close();
            }
            else
                MessageBox.Show("الصف موجود مسبقاً");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
