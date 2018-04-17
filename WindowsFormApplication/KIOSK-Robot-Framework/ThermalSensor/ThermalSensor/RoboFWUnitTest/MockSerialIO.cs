using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vn.Ntq.RoboFW.RoboCommunicator;

namespace RoboFWUnitTest
{
    class MockSerialIO : ISerialIO
    {
        ISerialReceiver listerner;

        public void Dispose()
        {
            
        }

        public string GetConnectionStatus()
        {
            throw new NotImplementedException();
        }

        public void RegisterOnReceiveListener(ISerialReceiver listerner)
        {
            this.listerner = listerner;
        }

        public void Send(byte[] data)
        {
            int remaim = data.Length;
            var a = new Random();
            
            while (remaim > 0)
            {
                int sendByte = Math.Min(1 + a.Next(10), remaim);

                var sendData = new byte[sendByte];
                Array.Copy(data, data.Length - remaim, sendData, 0, sendByte);

                listerner.OnReceiveData(sendData);

                remaim -= sendByte;
            }
        }
    }
}
