using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace Fan_1
{
   



    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        public delegate void a1();
        public event a1 aa1;


        // Tao ket noi


        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 form2 = new Form2();
            form2.ShowDialog();
            this.Close();
        }
 

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection connect = new SqlConnection(@"Data Source=Vinh\SQLEXPRESS;Initial Catalog=QuanLySV;Integrated Security=True");

                connect.Open();
                string sqlInsert = "INSERT INTO VINH2(MaSV,HoTen,MaLop) VALUES(@MaSV,@HoTen,@MaLop)";
                SqlCommand cmd1 = new SqlCommand(sqlInsert, connect);
                cmd1.Parameters.AddWithValue("@MaSV", Tb_MaSV.Text);
                cmd1.Parameters.AddWithValue("@HoTen", Tb_HoTen.Text);
                cmd1.Parameters.AddWithValue("@MaLop", Tb_MaLop.Text);
                cmd1.ExecuteNonQuery();

                //Long();
            }
            catch
            {
                MessageBox.Show("Lỗi Kết Nối");

            }


        }

        private void Form3_Load(object sender, EventArgs e)
        {

            //try
            //{
            //    SqlConnection connect = new SqlConnection(@"Data Source=Vinh\SQLEXPRESS;Initial Catalog=QuanLySV;Integrated Security=True");

            //    connect.Open();
            //    string sqlInsert = "INSERT INTO VINH2(MaSV,HoTen,MaLop) VALUES(@MaSV,@HoTen,@MaLop)";
            //    SqlCommand cmd1 = new SqlCommand(sqlInsert, connect);
            //    cmd1.Parameters.AddWithValue("@HoTen", Tb_HoTen.Text);
            //    cmd1.Parameters.AddWithValue("@MaSV",  Tb_MaSV.Text);
            //    cmd1.Parameters.AddWithValue("@MaLop", Tb_MaLop.Text);
            //    cmd1.ExecuteNonQuery();

            //    //Long();
            //}
            //catch
            //{
            //    MessageBox.Show("Lỗi Kết Nối");

            //}

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection connect = new SqlConnection(@"Data Source=Vinh\SQLEXPRESS;Initial Catalog=QuanLySV;Integrated Security=True");

                connect.Open();
                string sqlInsert = "DELETE FROM VINH2";
                SqlCommand cmd1 = new SqlCommand(sqlInsert, connect);
                cmd1.ExecuteNonQuery();

                //Long();
            }
            catch
            {
                MessageBox.Show("Lỗi Kết Nối");

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        //void Long()
        //{

        //    string sqlSelect = "SELECT * FROM VINH2";
        //    SqlCommand cmd2 = new SqlCommand(sqlSelect, connect);
        //}
    }
}
