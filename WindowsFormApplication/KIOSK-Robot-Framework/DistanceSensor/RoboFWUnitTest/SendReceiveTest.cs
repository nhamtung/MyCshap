using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RoboFWUnitTest;
using Vn.Ntq.RoboFW.Commands;
using Vn.Ntq.RoboFW.RoboCommunicator.Messages;

namespace Vn.Ntq.RoboFW.RoboCommunicator.Tests
{
    [TestClass()]
    public class SendReceiveTest : IMessageListener
    {
        static byte[] commandData;

        [ClassInitialize()]
        public static void ClassInit(TestContext context)
        {
            commandData = new byte[257];
            commandData[0] = 0x11;
            for (int i = 1; i < commandData.Length;i++)
            {
                commandData[i] = (byte)(i - 1);
            }
        }
        [TestMethod()]
        public void SendTest()
        {
            MessageTransporter st = new MessageTransporter("echo", new ResponseFactory());

            var msg = CreateMessage();

            st.RegisterListener((byte)(msg.getId() + 0x80), OnReceive);

            st.SendASync(msg);

            st.Dispose();

        }

        void OnReceive(RoboMessage message)
        {
            CollectionAssert.Equals(commandData, message.GetData());
        }

        [TestMethod()]
        public void EncodeMessageTest1()
        {
            RoboMessage message = CreateMessage();
            var encoded = MessageEncoder.EncodeMessage(message.GetData());
            var decoded = MessageEncoder.DecodeCommandData(encoded);
            CollectionAssert.AreEqual(commandData, decoded);
        }

        private RoboMessage CreateMessage()
        {
            return new ResponseFactory().Create(commandData);
        }

        void IMessageListener.OnReceive(RoboMessage message)
        {
            this.OnReceive(message);
        }
    }
}
