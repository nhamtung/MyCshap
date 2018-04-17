using Vn.Ntq.RoboFW.Commands;

namespace Vn.Ntq.RoboFW
{
    public class RoboMoveCommand : RoboCommand
    {
        protected int distance;

        public RoboMoveCommand(byte commandId, int distance) : base(new byte[] { commandId, (byte)(distance & 0xFF), (byte)(distance >> 8) })
        {
            this.distance = distance;
        }
    }
}