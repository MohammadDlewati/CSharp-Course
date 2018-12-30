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
    public partial class Subjects : Form
    {
        BL.CLS_Subject sub = new BL.CLS_Subject();
        DataTable dt;
        int IdClass; string Class;
        public Subjects(int IdClass,string Class)
        {
            InitializeComponent();
            this.IdClass = IdClass;
            this.Class = Class;
            RefreshTable();
            dtg.Columns[0].HeaderText = "رقم المادة";
            dtg.Columns[1].HeaderText = "اسم المادة";
            dtg.Columns[2].HeaderText = "العلامة";
            dtg.Columns[3].HeaderText = "حد النجاح";
            lblClass.Text = Class;
        }
        public void RefreshTable()
        {
            dt = sub.getSubjectForClass(IdClass);
            dtg.DataSource = dt;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddEditSubject sub = new AddEditSubject("Add", 0, "", 0, 0, IdClass);
            sub.ShowDialog();
            RefreshTable();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            AddEditSubject sub = new AddEditSubject("Edit", int.Parse(dtg.CurrentRow.Cells[0].Value.ToString()), dtg.CurrentRow.Cells[1].Value.ToString(), int.Parse(dtg.CurrentRow.Cells[2].Value.ToString()), int.Parse(dtg.CurrentRow.Cells[3].Value.ToString()), IdClass);
            sub.ShowDialog();
            RefreshTable();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("هل أنت متأكد من الحذف", "حذف", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                BL.CLS_Subject div = new BL.CLS_Subject();
                div.DeleteSubject(int.Parse(dtg.SelectedRows[0].Cells[0].Value.ToString()));
                RefreshTable();
            }
        }
    }
}
