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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnThongbao_Click(object sender, EventArgs e)
        {
            /*    string ThongBao; //khai bao bien ThongBao
                ThongBao = "Khóa học: \n\t lập trình C# \"cơ bản\"";   //gan gia tri bien

                int iSoNguyen = 1000000;

                //System.Globalization.CultureInfo cultureInfo = new System.Globalization.CultureInfo("vi-VN");

                MessageBox.Show(iSoNguyen.ToString("n0")+"đ");    //C la chuyen doi sang don vi tien dola  //n là dang so thuc, 3 là so chu so sau dau phay
                */

            DateTime dtNgayHienTai = DateTime.Now;

            MessageBox.Show(dtNgayHienTai.ToString("dd/MM/yyyy"));

        }
    }
}
