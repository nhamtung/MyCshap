namespace Vn.Ntq.RoboFW.RoboCommunicator.Messages
{
    public class PositionValue : RoboMessage
    {
        private byte address;
        private uint timestamp;

        public int x { get; private set; }
        public int y { get; private set; }
        public int z { get; private set; }

        public PositionValue(byte[] buffer) : base(buffer)
        {

            this.address =
            buffer[16];
            this.timestamp =
                (uint)buffer[5] |
                (((uint)buffer[6]) << 8) |
                (((uint)buffer[7]) << 16) |
                (((uint)buffer[8]) << 24);
            this.x =
                buffer[9] |
                (((int)buffer[10]) << 8);
            this.y =
                buffer[11] |
                (((int)buffer[12]) << 8);
            this.z =
                buffer[13] |
                (((int)buffer[14]) << 8);
        }

        public override byte getId()
        {
            return 0xB1;
        }
    }
}