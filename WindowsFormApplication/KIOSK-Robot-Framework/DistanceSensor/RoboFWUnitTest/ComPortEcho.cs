using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vn.Ntq.RoboFW.Commands;
using Vn.Ntq.RoboFW.RoboCommunicator;
using Vn.Ntq.RoboFW.RoboCommunicator.Messages;

namespace Vn.Ntq.RoboFW
{
    public class ComPortEcho : IMessageListener
    {
        IMessageTransporter messageTransorter;
        
        public ComPortEcho(String portName)
        {
            messageTransorter = new MessageTransporter(portName, new ResponseFactory());

            messageTransorter.RegisterListener(1, OnReceive);
        }


        public void OnReceive(RoboMessage message)
        {
            messageTransorter.SendASync(message);
        }
    }
}
