using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demo
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void btnTinhTong_Click(object sender, EventArgs e)
        {
            //lay du lieu ng dung nhap vao
            string sSoA = txtSoA.Text;
            string sSoB = txtSoB.Text;


            //kiem tra du lieu trong
            if(sSoA == "")
            {
                MessageBox.Show("Bạn chưa nhập số A");
                txtSoA.Focus();
                return;
            }
            if (sSoB == "")
            {
                MessageBox.Show("Bạn chưa nhập số B");
                txtSoB.Focus();
                return;
            }

            //chuyen kieu du lieu string sang int
            int A = Convert.ToInt16(sSoA);
            int B = Convert.ToInt16(sSoB);

            int C = A + B;

            string sSoC = Convert.ToString(C);

            /*//kiem tra lua chon 
            switch(cboPhepToan.Text)    //lấy tên phép toán
            {
                case "Cộng":
                    txtKetQua.Text = Convert.ToString(A + B);
                    break;
                case "Trừ":
                    txtKetQua.Text = Convert.ToString(A - B);
                    break;
                case "Nhân":
                    txtKetQua.Text = Convert.ToString(A * B);
                    break;
                case "Chia":
                    if(B==0)
                    {
                        MessageBox.Show("Bạn cần nhập số B khác 0");
                    }
                    else
                    {
                        txtKetQua.Text = Convert.ToString(A / B);
                    }
                    break;
                default:
                    MessageBox.Show("Bạn chưa chọn phép toán nao!");
                    break;
          }*/

            //kiem tra lua chon 
            switch(cboPhepToan.SelectedIndex)   //lấy vị trí hiển thị
            {
                case 0:
                    txtKetQua.Text = Convert.ToString(A + B);
                    break;
                case 1:
                    txtKetQua.Text = Convert.ToString(A - B);
                    break;
                case 2:
                    txtKetQua.Text = Convert.ToString(A * B);
                    break;
                case 3:
                    if(B==0)
                    {
                        MessageBox.Show("Bạn cần nhập số B khác 0");
                    }
                    else
                    {
                        txtKetQua.Text = Convert.ToString(A / B);
                    }
                    break;
                default:
                    MessageBox.Show("Bạn chưa chọn phép toán nao!");
                    break;
          }//*/
        }

        private void cboPhepToan_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
