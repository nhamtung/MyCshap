namespace Vn.Ntq.RoboFW.RoboCommunicator.Messages
{
    public class DefaultResponseFactory : IMessageCreator
    {
        public RoboMessage Create(byte[] data)
        {
            if (data == null || data.Length < 1)
            {
                return null;
            }
            return new RoboResponse(data); ;
        }

        public bool IsStartMessage(byte data)
        {
            return data == MessageSignal.START;
        }

        public bool IsEndMessage(byte data)
        {
            return data == MessageSignal.END;
        }

        public byte[] EncodeMessage(byte[] data)
        {
            return MessageEncoder.EncodeMessage(data);
        }

        public byte[] DecodeCommandData(byte[] data)
        {
            return MessageEncoder.DecodeCommandData(data);
        }
    }
}