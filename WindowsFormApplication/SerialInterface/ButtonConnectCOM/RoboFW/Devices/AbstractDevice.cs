using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vn.Ntq.RoboFW.Commands;
using Vn.Ntq.RoboFW.RoboCommunicator.Messages;

namespace Vn.Ntq.RoboFW.Sensors
{
    public abstract class DeviceSensor : IMessageListener
    {
        protected IMessageTransporter messageTransporter;

        public virtual void OnReceive(RoboMessage message)
        {
        }

        public DeviceSensor(IMessageTransporter messageTransporter)
        {
            this.messageTransporter = messageTransporter;
        }

        protected void SendCommand(byte commandId)
        {

            SendCommand(new RoboCommand(commandId));

        }

        protected void SendCommand(byte[] commanData)
        {

            SendCommand(new RoboCommand(commanData));

        }

        protected void SendCommand(RoboMessage message)
        {
            messageTransporter.SendASync(message);
        }



        protected void StartListener(byte messageId)
        {
            messageTransporter.RegisterListener(messageId, OnReceive);
        }


    }
}
