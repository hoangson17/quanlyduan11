using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppQuanly
{
    public partial class QuenMatKhau : Form
    {
        public QuenMatKhau()
        {
            InitializeComponent();
            label3.Text = "";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        Modify modify = new Modify();

        private void button1_Click(object sender, EventArgs e)
        {
            string email = textBox1.Text;
            if(email.Trim() == ""){ MessageBox.Show("Vui lòng nhập lại email đăng kí !!!"); }
            else
            {
                string query = "Select * from NHANVIEN where Email = '"+email+"'";
                if (modify.TaiKhoans(query).Count != 0){
                    label3.ForeColor = Color.Black;
                    label3.Text = "Mật Khẩu  : " + modify.TaiKhoans(query)[0].MatKhau;
                }
                else
                {
                    label3.ForeColor = Color.Red;
                    label3.Text = "Email này chưa được đăng ký !!!";
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void QuenMatKhau_Load(object sender, EventArgs e)
        {

        }
    }
}
