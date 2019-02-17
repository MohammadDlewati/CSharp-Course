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
    public partial class AddEditStudent : Form
    {
        int IdStudent, IdRegStudent;
        string NameStudent;
        string type;
        BL.CLS_Classes cla = new BL.CLS_Classes();
        BL.CLS_Division dla = new BL.CLS_Division();
        BL.CLS_Student std = new BL.CLS_Student();
        BL.CLS_RegStudent str = new BL.CLS_RegStudent();
        Setting.CLS_Getting Gett = new Setting.CLS_Getting();
        public AddEditStudent(string type,int IdStudent, string NameStudent, string AdressStudent, string TelphoneStudent, string MobilePhoneStudent, string BirthDay, string GenderStudent, string EmailStudent, byte[] ImageStudent, string NoteStudent)
        {
            InitializeComponent();
            DataTable dtc = cla.AllClasses();
            cmbClass.DataSource = dtc;
            cmbClass.ValueMember = "Id_Class";
            cmbClass.DisplayMember = "Class";
            cmbGender.Items.Add("ذكر");
            cmbGender.Items.Add("انثى");

            this.IdStudent = Gett.Get_numLastRecored()+1;
            txtIdStd.Text = this.IdStudent.ToString();
            this.NameStudent = NameStudent;
            this.type = type;
            if (type.Equals("Edit"))
            {
                DataTable dts = std.GetStudent(IdStudent);
                DataTable dtrs = str.GetRegStudent(IdStudent);

                txtIdStd.Text=IdStudent.ToString();
                txtNameStd.Text =dts.Rows[0]["NameStudent"].ToString();
                cmbGender.Text = dts.Rows[0]["GenderStudent"].ToString();
                txtTelphoneStd.Text = dts.Rows[0]["TelphoneStudent"].ToString();
                txtMobileStd.Text = dts.Rows[0]["MobilePhoneStudent"].ToString();
                dtpAgeStd.Text = dts.Rows[0]["BirthDay"].ToString();
                txtEmailStd.Text = dts.Rows[0]["EmailStudent"].ToString();
                txtAddressStd.Text = dts.Rows[0]["AdressStudent"].ToString();
                txtNoteStd.Text = dts.Rows[0]["NoteStudent"].ToString();

                byte[] byt = (byte[])dts.Rows[0]["ImageStudent"];
                picStd.Image = Setting.ImageDeal.ByteArrayToImage(byt);

                cmbClass.Text = Gett.Get_Class(int.Parse(dtrs.Rows[0]["IdClass"].ToString()));
                cmbDivision.Text = Gett.Get_Division(int.Parse(dtrs.Rows[0]["Id_Division"].ToString()));
                dateRegStudent.Text = dtrs.Rows[0]["DateReg"].ToString();
                this.IdRegStudent = int.Parse(dtrs.Rows[0]["IdRegStudent"].ToString());
                this.IdStudent = IdStudent;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            byte[] byt = Setting.ImageDeal.imageToByteArray(picStd.Image);
            
            if (type.Equals("Add"))
            {
                DataTable dt = std.VerifiyStudent(txtNameStd.Text);
                DataTable dtr = str.VerifiyRegStudent(txtNameStd.Text);

                if (dt.Rows[0][0].ToString().Equals("0"))
                {
                    std.AddStudent(txtNameStd.Text, txtAddressStd.Text, txtTelphoneStd.Text, txtMobileStd.Text,Setting.CLS_Setting.datetoString(dtpAgeStd.Value),cmbGender.Text,txtEmailStd.Text,byt,txtNoteStd.Text);

                    

                    str.AddRegStudent(IdStudent,txtNameStd.Text,Gett.Get_IdClass(cmbClass.Text),Gett.Get_IdDivision(cmbDivision.Text), Setting.CLS_Setting.datetoString(dateRegStudent.Value));
                    DialogResult result = MessageBox.Show("تم الحفظ. هل تريد إضافة طالب جديد؟", "حفظ", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        txtNameStd.Text = "";
                        txtAddressStd.Text = "";
                        txtTelphoneStd.Text = "";
                        txtMobileStd.Text = "";
                        
                    }
                    else
                        Close();
                }
                else
                    MessageBox.Show("الطالب موجود مسبقاً");
            }
            else
            {
                std.EditStudent(int.Parse(txtIdStd.Text), txtNameStd.Text, txtAddressStd.Text, txtTelphoneStd.Text, txtMobileStd.Text, Setting.CLS_Setting.datetoString(dtpAgeStd.Value), cmbGender.Text, txtEmailStd.Text, byt, txtNoteStd.Text);

                str.EditRegStudent(IdRegStudent,IdStudent, txtNameStd.Text, Gett.Get_IdClass(cmbClass.Text), Gett.Get_IdDivision(cmbDivision.Text), Setting.CLS_Setting.datetoString(dateRegStudent.Value));

                MessageBox.Show("تم الحفظ");
                Close();
                //DataTable dt = div.VerifiySubject(txtSubjectName.Text);
                //if (dt.Rows[0][0].ToString().Equals("0"))
                //{
                //div.EditSubject(IdSubject, txtSubjectName.Text, int.Parse(txtMark.Text), int.Parse(txtLimtSuccess.Text), IdClass);
                //}
                //else
                //MessageBox.Show("تم التعديل بنجاح");
                //txtSubjectName.ReadOnly = false;
                //Close();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void picStd_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "اختر صورة";
            ofd.Filter = "Image Files |*.jpg; *.png; *.gif;";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                picStd.Image = Image.FromFile(ofd.FileName);
            }
        }

        private void cmbClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dtd = dla.GetDivisionForClass(Gett.Get_IdClass(cmbClass.Text));
            cmbDivision.DataSource = dtd;
            cmbDivision.ValueMember = "IdDivision";
            cmbDivision.DisplayMember = "Division";
        }
    }
}
