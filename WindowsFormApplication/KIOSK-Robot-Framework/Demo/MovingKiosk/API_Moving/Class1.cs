using System;
using System.Windows.Forms;
using System.IO.Ports;   //goi thu vien truyen tin hieu qua cong COM bang giao thuc UART

namespace API_Moving
{
    public class class1
    {
        private SerialPort serial;

        public bool IsConnect
        {
            get
            {
                return serial.IsOpen;
            }
        }

        public class1()
        {
                serial = new SerialPort();
                serial.BaudRate = 115200;
        }

        public bool Connect(string com)
        {
            try
            {
                if (serial.IsOpen)
                {
                    serial.Close();
                }

                serial.PortName = com;
                serial.Open();    //connect UART

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
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void Forward()
        {
            SendCommand("A");
        }

        public void Backward()
        {
            SendCommand("B");
        }

        public void TurnLeft()
        {
            SendCommand("C");
        }

        public void TurnRight()
        {
            SendCommand("D");
        }

        public void FastSpeed()
        {
            SendCommand(0x46);
        }

        public void SlowSpeed()
        {
            SendCommand(0x45);
        }

        private void SendCommand(byte cmd)
        {
            serial.Write(new byte[] { cmd }, 0, 1);
        }

        private void SendCommand(string cmd)
        {
            serial.Write(cmd);
        }
    }
}
