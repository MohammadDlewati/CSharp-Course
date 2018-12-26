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
    }
}
