using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

namespace Vn.Ntq.RoboFW.Controllers
{
    public abstract class StateController
    { 
        public void Start()
        {
            if (InitConnection())  //gọi hàm InitConnection (kiểm tra có cổng COM nào kết nổi không)
            {
                MessageBox.Show("Connected to COM!");
            }
            else
            {
                MessageBox.Show("Not Connected to COM!");
            }
        }

        abstract protected bool InitConnection();
    }
}
