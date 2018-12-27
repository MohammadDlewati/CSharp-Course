using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            txtClass.Text=div.Div_Class(IdClass);
            txtDivisionName.Text = Division;
            id = IdDivision;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            BL.CLS_Division div = new BL.CLS_Division();
            DataTable dt = div.VerifiyDivision(txtDivisionName.Text, txtClass.Text);
            if (dt.Rows[0][0].ToString().Equals("0"))
            {
                int IdClass = div.Div_IdClass(txtClass.Text);
                div.EditDivision(id, txtDivisionName.Text, IdClass);
                Close();
            }
            else
                MessageBox.Show("الشعبة موجودة مسبقاً");
        }
    }
}
