using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanHang
{
    public partial class frmDangNhap : Form
    {

        string[,] arrTaiKhoan = new string[3, 2];

        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {

            /*if (txtTenTruyCap.Text.Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập tên truy cập!");
                return;
            }  
            
            if(string.IsNullOrEmpty(txtTenTruyCap.Text))
            {
                MessageBox.Show("Bạn chưa nhập tên truy cập!");
                return;
            }//*/

            if (txtTenTruyCap.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên truy cập!","CẢNH BÁO", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                txtTenTruyCap.Focus();
                return;
            }

            if (txtMatKhau.Text.Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập mật khẩu!", "CẢNH BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMatKhau.Focus();
                return;
            }

            //if((txtTenTruyCap.Text == "admin") && (txtMatKhau.Text == "admin"))
            //    MessageBox.Show("Bạn đã đăng nhập thành công!","THÔNG BÁO", MessageBoxButtons.OK,MessageBoxIcon.Information);
            //else
            //    MessageBox.Show("Bạn nhập sai tên truy cập hoặc mật khẩu!");

            for(int i=0; i<3; i++)
            {
                string TenTruyCap = arrTaiKhoan[i, 0];
                string MatKhau = arrTaiKhoan[i, 1];

                if(TenTruyCap == txtTenTruyCap.Text && MatKhau == txtMatKhau.Text )
                {
                    MessageBox.Show("Bạn đã đăng nhập thành công!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            MessageBox.Show("Bạn nhập sai tên truy cập hoặc mật khẩu!");
        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {
            arrTaiKhoan[0, 0] = "admin1";
            arrTaiKhoan[0, 1] = "pass1";

            arrTaiKhoan[1, 0] = "admin2";
            arrTaiKhoan[1, 1] = "pass2";

            arrTaiKhoan[2, 0] = "admin3";
            arrTaiKhoan[2, 1] = "pass3";
        }
    }
}
