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

        protected void SendCommand(byte[] commanData)  //truyền data với tham biến: byte[] commanData = [0x22, SensorOnFlag];
        {
            SendCommand(new RoboCommand(commanData));  //gọi hàm RoboCommand với tham biến commanData, gọi hàm Sendcommand
        }

        protected void SendCommand(RoboMessage message)  //RoboMessage message = new RoboCommand(commanData); //khởi tạo 1 đối tượng message trong RoboMessage
        {
            messageTransporter.SendASync(message);  //gọi hàm SendASync trong messageTransporter với tham biến message (mã hóa dữ liệu)
        }
        
        protected void StartListener(byte messageId)  //messageId = 0xA1
        {
            messageTransporter.RegisterListener(messageId, OnReceive);  //gọi hàm registerListener trong AbstractMessageTransporter
        }
    }
}
