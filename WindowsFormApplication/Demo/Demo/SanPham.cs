using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    public class SanPham
    {
        //Thuộc tính - property
        /// <summary>
        /// Mã sản phẩm
        /// </summary>
        public string MaSanPham { set; get; }

        /// <summary>
        /// Tên sản phẩm
        /// </summary>
        public string TenSanPham { set; get; }

        /// <summary>
        /// Giá bán
        /// </summary>
        public decimal GiaBan { set; get; }

        /// <summary>
        /// Giá bán
        /// </summary>
        public decimal SoLuong { set; get; }

        /// <summary>
        /// Ngày Nhập
        /// </summary>
        public DateTime NgayNhap { set; get; }

        //Phương thức
        public decimal TinhThanhTien()
        {
            decimal ThanhTien = GiaBan * SoLuong;
            return ThanhTien;
        } 
    }
}
