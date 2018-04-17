using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Google.GData.Client;
using Google.Contacts;
using Google.GData.Extensions;
using Google.GData.Contacts;

namespace GetListContactGmail
{
    public partial class Contacts : Form
    {
        public Contacts()
        {
            InitializeComponent();
        }

        public List<GoogleContacts> list;
        public List<GoogleContacts> GetGoogleContacts(string appName, string un, string pwd)
        {
            List<GoogleContacts> contactList = new List<GoogleContacts>();
            RequestSettings settings = new RequestSettings(appName, un, pwd);
            settings.AutoPaging = true;
            ContactsRequest request = new ContactsRequest(settings);
            Feed<Contact> feed = request.GetContacts();
            //foreach (Contact contact in feed.Entries)
            //{
            //    GoogleContacts c = new GoogleContacts();
            //    c.title = string.IsNullOrEmpty(contact.Title) ? "Chua dat ten" : contact.Title;
            //    c.im = contact.IMs.Count == 0 ? " " : contact.IMs[0].Address;
            //    c.email = contact.Emails.Count == 0 ? " " : contact.Emails[0].Address;
            //    contactList.Add(c);
            //}
            return contactList;
        }

        public void addContactsToListBox(List<GoogleContacts> contactList)
        {
            labName.Text = "Số liên hệ trong danh sách: " + contactList.Count.ToString();

            foreach (GoogleContacts contact in contactList)
            {
                listBoxContent.Items.Add(contact.title + " - " + contact.email + " - " + contact.im);
            }
        }

        public void setText(string a, string b, string c)
        {
            list = GetGoogleContacts(a, b, c);
        }

        private void Contacts_Load(object sender, EventArgs e)
        {
            addContactsToListBox(list);
        }
    }

    public class GoogleContacts
    {
        public string title { get; set; }
        public string email { get; set; }
        public string im { get; set; }
    }
}
