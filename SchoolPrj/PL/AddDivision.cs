using System;
using System.Data;
using System.Windows.Forms;

namespace SchoolPrj.PL
{
    public partial class AddDivision : Form
    {
        BL.CLS_Classes cla = new BL.CLS_Classes();
        DataTable dt;
        public AddDivision()
        {
            InitializeComponent();
            dt = cla.AllClasses();
            cmbClass.DataSource = dt;
            cmbClass.ValueMember = "Id_Class";
            cmbClass.DisplayMember = "Class";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            BL.CLS_Division div = new BL.CLS_Division();
            DataTable dt = div.VerifiyDivision(txtDivisionName.Text,cmbClass.Text);
            if (dt.Rows[0][0].ToString().Equals("0"))
            {
                div.AddDivision(txtDivisionName.Text,cmbClass.Text);
                DialogResult result = MessageBox.Show("تم الحفظ. هل تريد إضافة شعبة جديدة؟", "حفظ", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    txtDivisionName.Text = "";
                }
                else
                    Close();
            }
            else
                MessageBox.Show("الشعبة موجودة مسبقاً");
        }
    }
}
