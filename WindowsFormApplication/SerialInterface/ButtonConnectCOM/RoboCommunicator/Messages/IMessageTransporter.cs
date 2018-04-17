using System;

namespace Vn.Ntq.RoboFW.RoboCommunicator.Messages
{
    public delegate void ReceivedMessageEventHandler(RoboMessage msg);

    public interface IMessageTransporter : IDisposable
    {

        void SendASync(RoboMessage message);

        RoboMessage SendSync(RoboMessage command, byte responseId);

        void RegisterListener(byte messageId, ReceivedMessageEventHandler listener);

        void Reconnect();
    }
}
