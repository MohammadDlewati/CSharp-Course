using System;
using System.Data;
using System.Windows.Forms;

namespace SchoolPrj.PL
{
    public partial class Classes : Form
    {
        public Classes()
        {
            InitializeComponent();
        }

        public void RefreshTable()
        {
            BL.CLS_Classes cla = new BL.CLS_Classes();
            DataTable dt = cla.AllClasses();
            dtg.DataSource = dt;
        }
        private void Classes_Load(object sender, EventArgs e)
        {
            RefreshTable();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddClass ac = new AddClass();
            ac.ShowDialog();
            RefreshTable();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            EditClass ec = new EditClass(int.Parse(dtg.SelectedRows[0].Cells[0].Value.ToString()), dtg.SelectedRows[0].Cells[1].Value.ToString());
            ec.ShowDialog();
            RefreshTable();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("هل أنت متأكد من الحذف", "حذف", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                BL.CLS_Classes usr = new BL.CLS_Classes();
                usr.DeleteClass(int.Parse(dtg.SelectedRows[0].Cells[0].Value.ToString()));
                RefreshTable();
            }
        }
    }
}
