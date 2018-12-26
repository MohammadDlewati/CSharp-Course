using System;
using System.Data;
using System.Windows.Forms;

namespace SchoolPrj.PL
{
    public partial class User : Form
    {
        public User()
        {
            InitializeComponent();
        }

        private void User_Load(object sender, EventArgs e)
        {
            RefreshTable();
        }

        public void RefreshTable()
        {
            BL.CLS_Users usr = new BL.CLS_Users();
            DataTable dt = usr.AllUser();
            dtg.DataSource = dt;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("هل أنت متأكد من الحذف", "حذف", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                BL.CLS_Users usr = new BL.CLS_Users();
                usr.DeleteUser(int.Parse(dtg.SelectedRows[0].Cells[0].Value.ToString()));
                RefreshTable();
            }            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddUser au = new AddUser();
            au.ShowDialog();
            RefreshTable();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            EditUser eu = new EditUser(int.Parse(dtg.SelectedRows[0].Cells[0].Value.ToString()), dtg.SelectedRows[0].Cells[1].Value.ToString(), dtg.SelectedRows[0].Cells[2].Value.ToString());
            eu.ShowDialog();
            RefreshTable();
        }
    }
}
