using Google.Contacts;
using Google.GData.Client;
using System;
using System.Windows.Forms;

namespace GetListContactGmail
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            txtPass.PasswordChar = '*';
        }
        private Service service;
        private string authToken;

        public Form1(Service serviceToUse)
        {
            InitializeComponent();
            service = serviceToUse;
        }

        public Form1(Service serviceToUse, string username)
        {
            InitializeComponent();
            service = serviceToUse;
            txtUser.Text = username;
        }

        public string AuthenticationToken
        {
            get
            {
                return authToken;
            }
        }

        public bool RememberAuthentication
        {
            get
            {
                return checkBoxRemember.Visible;
            }
            set
            {
                checkBoxRemember.Visible = value;
            }
        }

        public string user
        {
            get
            {
                return txtUser.Text;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            Contacts fC = new Contacts();
            fC.setText("GoogleTest", txtUser.Text, txtPass.Text);
            fC.Show();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            authToken = null;
            this.Close();
        }

        private void txtUser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(null, null);
            }
        }

        private void txtPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(null, null);
            }
        }
    }
}
