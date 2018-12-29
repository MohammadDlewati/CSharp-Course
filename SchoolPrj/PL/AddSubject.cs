using System;
using System.Data;
using System.Windows.Forms;

namespace SchoolPrj.PL
{
    public partial class AddSubject : Form
    {
        int IdClass;
        public AddSubject(int IdClass)
        {
            InitializeComponent();
            this.IdClass = IdClass;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            BL.CLS_Subject div = new BL.CLS_Subject();
            DataTable dt = div.VerifiySubject(txtSubjectName.Text);
            if (dt.Rows[0][0].ToString().Equals("0"))
            {
                div.AddSubject(txtSubjectName.Text, int.Parse(txtMark.Text),int.Parse(txtLimtSuccess.Text),IdClass);
                DialogResult result = MessageBox.Show("تم الحفظ. هل تريد إضافة مادة جديدة؟", "حفظ", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    txtSubjectName.Text = "";
                    txtMark.Text = "";
                    txtLimtSuccess.Text = "";
                }
                else
                    Close();
            }
            else
                MessageBox.Show("المادة موجودة مسبقاً");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
    
}
