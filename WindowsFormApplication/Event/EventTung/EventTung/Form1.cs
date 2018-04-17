using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Event
{
    public partial class Form1 : Form
    {
        private EventPublisher eventPublisher = new EventPublisher();
        public Form1()
        {
            InitializeComponent();

            eventPublisher.updateNumberEvent += DisplayNumber;
            Execute();
        }

        public void Execute()
        {
            Task.Run(() =>
            {
                while(true)
                {
                    eventPublisher.DoSomething();
                    Thread.Sleep(1000);
                }
            });
        }

        public void DisplayNumber(int num)
        {
            try
            {
                this.Invoke((MethodInvoker)delegate
                {
                    txtBox.Text = Convert.ToString(num);
                });
            }
            catch(Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex));
            }
        }
    }
}
