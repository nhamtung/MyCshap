using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vn.Ntq.RoboFW.RoboCommunicator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Vn.Ntq.RoboFW.RoboCommunicator.Tests
{
    [TestClass()]
    public class ComPortIOTests : ISerialReceiver
    {
        byte[] bytesToSend = new byte[] { 0, 1, 2, 3, 4, 5, 255, 254, 253, 252 };

        [TestMethod()]
        public void SendTest()
        {

            ComPortIO serialIO4 = new ComPortIO("COM4");

            serialIO4.RegisterOnReceiveListener(this);

            ComPortIO serialIO3 = new ComPortIO("COM3");

            serialIO3.Send(bytesToSend);

            Thread.Sleep(1000);

            serialIO4.Dispose();

            serialIO3.Dispose();

        }

        public void OnReceiveData(byte[] data)
        {
            CollectionAssert.AreEqual(this.bytesToSend, data);
        }
    }
}