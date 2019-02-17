using System;
using System.Data;
using System.Windows.Forms;

namespace SchoolPrj.PL
{
    public partial class EditDivision : Form
    {
        int id;
        string Class;
        public EditDivision(int IdDivision,string Division,int IdClass)
        {
            InitializeComponent();
            BL.CLS_Division div = new BL.CLS_Division();
            Setting.CLS_Getting Gett = new Setting.CLS_Getting();
            txtClass.Text=Gett.Get_Class(IdClass);
            txtDivisionName.Text = Division;
            id = IdDivision;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            BL.CLS_Division div = new BL.CLS_Division();
            Setting.CLS_Getting Gett = new Setting.CLS_Getting();
            DataTable dt = div.VerifiyDivision(txtDivisionName.Text, txtClass.Text);
            if (dt.Rows[0][0].ToString().Equals("0"))
            {
                int IdClass = Gett.Get_IdClass(txtClass.Text);
                div.EditDivision(id, txtDivisionName.Text, IdClass);
                Close();
            }
            else
                MessageBox.Show("الشعبة موجودة مسبقاً");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
