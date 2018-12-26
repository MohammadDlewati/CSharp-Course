using System;
using System.Data;
using System.Windows.Forms;

namespace SchoolPrj.PL
{
    public partial class AddClass : Form
    {
        public AddClass()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {            
            BL.CLS_Classes cla = new BL.CLS_Classes();
            DataTable dt = cla.VerifiyClass(txtClassName.Text);
            if (dt.Rows[0][0].ToString().Equals("0"))
            {
                cla.AddClass(txtClassName.Text);
                DialogResult result = MessageBox.Show("تم الحفظ. هل تريد إضافة صف جديد؟", "حفظ", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    txtClassName.Text = "";
                }
                else
                    Close();
            }
            else
                MessageBox.Show("الصف موجود مسبقاً");
        }
    }
}
