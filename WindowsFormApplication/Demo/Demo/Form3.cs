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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            #region Lấy dữ liệu người dùng
            /*   string MaSanPham = txtMaSanPham.Text;
               string TenSanPham = txtTenSanPham.Text;
               decimal GiaBan = numGiaBan.Value;   //kieu so thuc
               DateTime NgayNhap = dtNgayNhap.Value;  //*/

            SanPham objSanPham = new SanPham();
            objSanPham.MaSanPham = txtMaSanPham.Text;
            objSanPham.TenSanPham = txtTenSanPham.Text;
            objSanPham.GiaBan = numGiaBan.Value;
            objSanPham.SoLuong = numSoLuong.Value;
            objSanPham.NgayNhap = dtNgayNhap.Value;
            #endregion

            #region Kiểm tra tính hợp lệ của dữ liệu
            /*    if (string.IsNullOrEmpty(MaSanPham))
                {
                    MessageBox.Show("Bạn chưa nhập Mã Sản Phẩm!");
                    txtMaSanPham.Focus();
                    return;
                }//*/

                if (string.IsNullOrEmpty(objSanPham.MaSanPham))
                {
                    MessageBox.Show("Bạn chưa nhập Mã Sản Phẩm!");
                    txtMaSanPham.Focus();
                    return;
                }//*/

 /*           if (string.IsNullOrEmpty(TenSanPham))
            {
                MessageBox.Show("Bạn chưa nhập Tên Sản Phẩm!");
                txtTenSanPham.Focus();
                return;
            }//*/
            if (string.IsNullOrEmpty(objSanPham.TenSanPham))
            {
                MessageBox.Show("Bạn chưa nhập Tên Sản Phẩm!");
                txtTenSanPham.Focus();
                return;
            }

/*            if (GiaBan <= 0)
            {
                MessageBox.Show("Bạn chưa nhập Giá Bán!");
                numGiaBan.Focus();
                return;
            }//*/
            if (objSanPham.GiaBan <= 0)
            {
                MessageBox.Show("Bạn chưa nhập Giá Bán!");
                numGiaBan.Focus();
                return;
            }

            if (objSanPham.SoLuong <= 0)
            {
                MessageBox.Show("Bạn chưa nhập Số Lượng!");
                numSoLuong.Focus();
                return;
            }
            #endregion

            #region hiển thị dữ liệu lên danh sách sản phẩm - sử dụng string cơ bản
            /*           string ThongTinSanPham = MaSanPham;
                       ThongTinSanPham += " | ";
                       ThongTinSanPham += TenSanPham;
                       ThongTinSanPham += " | ";
                       ThongTinSanPham += GiaBan.ToString("N2");
                       ThongTinSanPham += " | ";
                       ThongTinSanPham += NgayNhap.ToString("dd/MM/yyyy HH:mm:ss");

                       rtxtDanhSachSanPham.Text += ThongTinSanPham + "\n";//*/
            #endregion

            #region hiển thị dữ liệu lên danh sách sản phẩm - sử dụng stringBuilder
            /*     StringBuilder ThongTinSanPham = new StringBuilder(MaSanPham);
                 ThongTinSanPham.Append(" | ");
                 ThongTinSanPham.Append(TenSanPham);
                 ThongTinSanPham.Append(" | ");
                 ThongTinSanPham.Append(GiaBan.ToString("N2"));
                 ThongTinSanPham.Append(" | ");
                 ThongTinSanPham.Append(NgayNhap.ToString("dd/MM/yyyy HH:mm:ss"));
                 ThongTinSanPham.Append("\n");

                 rtxtDanhSachSanPham.Text += ThongTinSanPham.ToString();//*/

            StringBuilder ThongTinSanPham = new StringBuilder(XuLyChuoi.VietHoa(objSanPham.MaSanPham,"Mã Sản Phẩm"));
            ThongTinSanPham.Append(" | ");
            ThongTinSanPham.Append(XuLyChuoi.VietHoa(objSanPham.TenSanPham,"Tên Sản Phẩm"));
            ThongTinSanPham.Append(" | ");
            ThongTinSanPham.Append(objSanPham.GiaBan.ToString("N2"));
            ThongTinSanPham.Append(" | ");
            ThongTinSanPham.Append(objSanPham.SoLuong.ToString("N0"));
            ThongTinSanPham.Append(" | ");
            ThongTinSanPham.Append(objSanPham.TinhThanhTien().ToString("N2"));
            ThongTinSanPham.Append(" | ");
            ThongTinSanPham.Append(objSanPham.NgayNhap.ToString("dd/MM/yyyy HH:mm:ss"));
            ThongTinSanPham.Append("\n");

            rtxtDanhSachSanPham.Text += ThongTinSanPham.ToString();//*/ 
            #endregion
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
