using Vn.Ntq.RoboFW.Commons;

namespace Vn.Ntq.RoboFW.RoboCommunicator.Messages
{
    public static class MessageSignal
    {
        public const byte START = 0xFD;
        public const byte END = 0xFE;
        public const byte MAX = 0xFC;
    }

    public abstract class RoboMessage
    {
        protected byte[] data;

        public byte[] GetData()
        {
            return data;
        }

        virtual public byte getId()
        {
            return data[0];
        }

        public override int GetHashCode()
        {
            return data == null || data.Length == 0? -1 : data[0];
        }
        public RoboMessage(byte[] data)
        {
            this.data = data;
        }

        public string GetHexString()
        {
            return Utils.ByteArrayToHexString(data);
        }
    }
}
