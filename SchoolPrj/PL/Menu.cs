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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            User usr = new User();
            usr.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            
        }

        private void btnClasses_Click(object sender, EventArgs e)
        {
            Classes cla = new Classes();
            cla.ShowDialog();
        }

        private void btnDivision_Click(object sender, EventArgs e)
        {
            Divisions div = new Divisions();
            div.ShowDialog();
        }

        private void btnSubject_Click(object sender, EventArgs e)
        {
            SelectClass sc = new SelectClass();
            sc.ShowDialog();
        }
    }
}
