using System;
using System.IO.Ports;  //goi thu vien truyen tin hieu qua cong COM bang giao thuc UART
using System.Windows.Forms;  

namespace Kiosk
{
    public class Robot
    {
        private SerialPort serial;

        public bool IsConnect
        {
            get
            {
                return serial.IsOpen;
            }
        }

        public Robot()
        {
            serial = new SerialPort();
            serial.BaudRate = 115200;
        }

        public bool Connect(string com)
        {
            try   //try ... catch la ham kiem tra loi
            {
                if (serial.IsOpen)
                {
                    serial.Close();
                }

                serial.PortName = com;
                serial.Open();

                if (serial.IsOpen)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }

        public void Disconnect()
        {
            try
            {
                if (serial.IsOpen)
                {
                    serial.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void Forward()
        {
            try
            {
                serial.Write(new byte[] {0x41 }, 0, 1);   //gui ma 0x41 trong mang byte, bat dau tu vi tri byte[0] va gui 1 phan tu
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public void Backward()
        {
            try
            {
                serial.Write("B");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public void TurnLeft()
        {
            try
            {
                serial.Write("C");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public void TurnRight()
        {
            try
            {
                serial.Write("D");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
  /*      public void Command(byte cmd)     //gui ma hex
        {
            serial.Write(new byte[] { cmd }, 0, 1);
        }//*/
    }
}
