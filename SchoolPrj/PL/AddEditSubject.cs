using System;
using System.Data;
using System.Windows.Forms;

namespace SchoolPrj.PL
{
    public partial class AddEditSubject : Form
    {
        int IdClass;
        int IdSubject;
        string type;
        public AddEditSubject(string type,int IdSubject,string NameSubject,int Mark,int LimtSuccess, int IdClass)
        {
            InitializeComponent();
            this.IdClass = IdClass;
            this.type = type;
            if (type.Equals("Edit"))
            {
                txtSubjectName.Text = NameSubject;
                txtSubjectName.ReadOnly = true;
                txtMark.Text = Mark.ToString();
                txtLimtSuccess.Text = LimtSuccess.ToString();
                this.IdSubject = IdSubject;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            BL.CLS_Subject div = new BL.CLS_Subject();
            if (type.Equals("Add"))
            {
                
                DataTable dt = div.VerifiySubject(txtSubjectName.Text);
                if (dt.Rows[0][0].ToString().Equals("0"))
                {
                    div.AddSubject(txtSubjectName.Text, int.Parse(txtMark.Text), int.Parse(txtLimtSuccess.Text), IdClass);
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
            else
            {
                //DataTable dt = div.VerifiySubject(txtSubjectName.Text);
                //if (dt.Rows[0][0].ToString().Equals("0"))
                //{
                    div.EditSubject(IdSubject, txtSubjectName.Text, int.Parse(txtMark.Text), int.Parse(txtLimtSuccess.Text), IdClass);
                //}
                //else
                    MessageBox.Show("تم التعديل بنجاح");
                txtSubjectName.ReadOnly = false;
                Close();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
    
}
