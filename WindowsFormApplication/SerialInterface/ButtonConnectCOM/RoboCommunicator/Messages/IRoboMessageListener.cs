namespace Vn.Ntq.RoboFW.RoboCommunicator.Messages
{
    public interface IMessageListener
    {
        void OnReceive(RoboMessage message);
    }
}