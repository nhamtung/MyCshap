using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vn.Ntq.RoboFW.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vn.Ntq.RoboFW.RoboCommunicator.Messages;
using RoboFWUnitTest;
using Vn.Ntq.RoboFW.Commons;
using System.Threading;
using Vn.Ntq.RoboFW.RoboCommunicator;

namespace Vn.Ntq.RoboFW.Commands.Tests
{
    [TestClass()]
    public class CommandSenderTests
    {
        private void showCommand(RoboMessage msg)
        {
            Console.WriteLine(Utils.ByteArrayToHexString(msg.GetData()));
        }

        [TestMethod()]
        public void SendSyncTest()
        {
            ComPortEcho echo = new ComPortEcho("COM4");

            IMessageTransporter sender3 = MessageTransporter.getInstance("COM3");

            //CommandSender.ReceivedMessageEventHandler list1 = new CommandSender.ReceivedMessageEventHandler("a");

            sender3.RegisterListener(1, showCommand);

            sender3.RegisterListener(3, showCommand);

            sender3.RegisterListener(5, showCommand);

            ResponseFactory cf = new ResponseFactory();

            RoboCommand mess = new RoboMoveForwardCommand(100);

            RoboMessage rec = sender3.SendSync(mess, mess.getResponseId());

            Assert.AreEqual(mess.getResponseId(), rec.getId());

            Thread.Sleep(2000);
        }
    }
}