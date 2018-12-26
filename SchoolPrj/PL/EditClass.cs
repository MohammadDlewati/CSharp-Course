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
            cla.EditClass(id, txtClassName.Text);
            Close();
        }
    }
}
