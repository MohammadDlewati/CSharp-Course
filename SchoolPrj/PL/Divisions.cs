using System;
using System.Data;
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("هل أنت متأكد من الحذف", "حذف", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                BL.CLS_Division div = new BL.CLS_Division();
                div.DeleteDivision(int.Parse(dtg.SelectedRows[0].Cells[0].Value.ToString()));
                RefreshTable();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            EditDivision ed = new EditDivision(int.Parse(dtg.SelectedRows[0].Cells[0].Value.ToString()), dtg.SelectedRows[0].Cells[1].Value.ToString(), int.Parse(dtg.SelectedRows[0].Cells[2].Value.ToString()));
            ed.ShowDialog();
            RefreshTable();
        }
    }
}
