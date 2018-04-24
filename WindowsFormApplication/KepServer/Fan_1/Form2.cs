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
//using System.Data;


namespace Fan_1
{
    public partial class Form2 : Form
    {
        public delegate void a();
        public event a aa;

        public Form2()
        {
            InitializeComponent();
        }
        // Tao ket noi
        SqlConnection connect = new SqlConnection(@"Data Source=Vinh\SQLEXPRESS;Initial Catalog=QuanLySV;Integrated Security=True");





        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.ShowDialog();
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

         void Form2_Load(object sender, EventArgs e)
        {
            //connect.Open(); // mmở kết nối
            //string sql = "select Vinh2.HoTen,MaSV,MaLop From Vinh2  ";// Câu lệnh sql
            //SqlCommand cmd = new SqlCommand(sql, connect);// thực hiện câu lệnh truy vấn này đến sql
            //cmd.CommandType = CommandType.Text;
            //SqlDataAdapter da = new SqlDataAdapter(cmd) ;// Lưu dữ liệu lấy được vào đây
            //DataTable dt = new DataTable();// Tạo 1 kho dữ liệu ảo 
            //da.Fill(dt);// đổ dữ liệu vào kho
            //dataGridView1.DataSource = dt;
            //connect.Close();




        }

        private void button2_Click(object sender, EventArgs e)
        {

            try
            { 
            connect.Open(); // mmở kết nối MaSV,HoTen,MaLop
            string sql = "select MaSV,HoTen,MaLop  From Vinh2  ";// Câu lệnh sql
            SqlCommand cmd = new SqlCommand(sql, connect);// thực hiện câu lệnh truy vấn này đến sql
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(cmd);// Lưu dữ liệu lấy được vào đây
            DataTable dt = new DataTable();// Tạo 1 kho dữ liệu ảo 
            da.Fill(dt);// đổ dữ liệu vào kho
            dataGridView1.DataSource = dt;
            connect.Close();
            }
            catch
            {
                MessageBox.Show("Lỗi Kết Nối");

            }


        }

   

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 form3 = new Form3();
            form3.ShowDialog();
            this.Close();
        }

      
    }
}
