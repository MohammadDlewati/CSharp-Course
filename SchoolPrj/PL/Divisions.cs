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
    public partial class Divisions : Form
    {
        public Divisions()
        {
            InitializeComponent();
        }
        public void RefreshTable()
        {
            BL.CLS_Division div = new BL.CLS_Division();
            DataTable dt = div.AllDivision();
            dtg.DataSource = dt;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddDivision div = new AddDivision();
            div.ShowDialog();
            RefreshTable();
        }

        private void Divisions_Load(object sender, EventArgs e)
        {
            RefreshTable();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
