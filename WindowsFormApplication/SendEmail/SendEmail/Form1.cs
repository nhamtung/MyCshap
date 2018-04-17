using System;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;

namespace SendEmail
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                /*
                 * Note: 
                 * - Using account google to send mail.
                 * - Check DNS google: 8888 8844.
                 * - Allow less secure apps by:
                 * + Login account google.
                 * + Access link: https://myaccount.google.com/lesssecureapps
                 * + Turn on Allow less secure apps.
                 */

                MailMessage msg = new MailMessage(txtFrom.Text, txtTo.Text, txtSubject.Text, txtMessage.Text);
                if (!string.IsNullOrEmpty(txtCC.Text))
                    msg.To.Add(new MailAddress(txtCC.Text));
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.UseDefaultCredentials = false;
                NetworkCredential cre = new NetworkCredential(txtFrom.Text, txtPasswords.Text);//your mail password
                client.Credentials = cre;
                client.EnableSsl = true;
                client.Send(msg);

                MessageBox.Show("Mail send success fully!");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Send error \n" + Convert.ToString(ex));
            }
        }
    }
}
