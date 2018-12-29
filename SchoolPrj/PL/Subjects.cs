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
            AddSubject sub = new AddSubject(IdClass);
            sub.ShowDialog();
            RefreshTable();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
