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
    public partial class SelectClass : Form
    {
        BL.CLS_Classes src = new BL.CLS_Classes();
        DataTable dt;
        public SelectClass()
        {
            InitializeComponent();
            RefreshTable();
            dtg.Columns[0].HeaderText = "رقم الصف";
            dtg.Columns[1].HeaderText = "اسم الصف";
        }

        public void RefreshTable()
        {
            dt = src.AllClasses();
            dtg.DataSource = dt;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dtg_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Subjects sub = new Subjects(int.Parse(dtg.Rows[e.RowIndex].Cells[0].Value.ToString()), dtg.Rows[e.RowIndex].Cells[1].Value.ToString());
                sub.ShowDialog();
            }
        }
    }
}
